/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "dma.h"
#include "i2c.h"
#include "tim.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "stdio.h"
#include "bno055_stm32.h"
#include "ms5611.h"
#include "string.h"
#include "control.h"
#include "tof.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
#define MAIN_SELENOID_TIMEOUT 300 // 300 * 10ms = 3 secs
#define MAIN_SELENOID_HEIGHT  700 // 700cm = 7m

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */

const uint8_t tele_header[] = "Time,Roll,Pitch,Heading,Temperature,Pressure,Distance\n";
uint8_t recv = 0xCD;


float temp = 0;
float pressure = 0;

volatile uint8_t IMU_DTRDY = 0;

bno055_vector_t v;

volatile uint8_t SD_LOG_RDY = 0;
volatile uint8_t BATTERY_RDY = 0;
volatile uint8_t TELEMETRY_RDY = 0;
volatile uint8_t MAIN_THRST_ACTIVATE = GPIO_PIN_RESET;
volatile uint8_t MAIN_THRST_LOCK 	 = 0;

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_I2C1_Init();
  MX_USART6_UART_Init();
  MX_I2C3_Init();
  MX_TIM4_Init();
  MX_USART2_UART_Init();
  MX_USART1_UART_Init();
  /* USER CODE BEGIN 2 */

  TOF_UART_Init(&huart1);

	HAL_GPIO_WritePin(APC220_SET_GPIO_Port, APC220_SET_Pin, GPIO_PIN_SET);

	ms5611_set_i2c(&hi2c3);
	ms5611_init();

	bno055_assignI2C(&hi2c1);
	bno055_setup();
	bno055_setOperationModeNDOF();


	HAL_Delay(5000);

	HAL_UART_Receive(&huart2, &recv, 1, 100);
	HAL_UART_Transmit_DMA(&huart2, tele_header, sizeof(tele_header));
	HAL_UART_Receive(&huart2, &recv, 1, 100);

	HAL_GPIO_WritePin(LED_GPIO_Port, LED_Pin, GPIO_PIN_SET);

	while(HAL_GPIO_ReadPin(Safety_GPIO_Port, Safety_Pin) == GPIO_PIN_SET);

	HAL_TIM_Base_Start_IT(&htim4);


  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */

	if (!MAIN_THRST_LOCK && (tof_meas < MAIN_SELENOID_HEIGHT)) {
		MAIN_THRST_ACTIVATE = GPIO_PIN_SET;
		MAIN_THRST_LOCK = 1;
	}

	if (IMU_DTRDY) {
		v = bno055_getVectorEuler();
		printf("Roll: %.2f\tPitch: %.2f\tYaw: %.2f\n", v.x, v.y, v.z);
		IMU_DTRDY = 0;

		ms5611_update();
		temp = ms5611_get_temperature();
		pressure = ms5611_get_pressure();
		printf("Temp: %.2f\tPressure: %.2f\n", temp, pressure);

		Control(&SELENOID_STATES, v.x, v.y);
	}

	if(SD_LOG_RDY){
		char s[150] = {0};
		sprintf(s, "%ld,%.2f,%.2f,%.2f,%.2f,%.2f,%d\n", HAL_GetTick(), v.x, v.y, v.z, temp, pressure, tof_meas);
		uint8_t len = strlen(s);
		HAL_UART_Transmit_DMA(&huart2, (const uint8_t*) s, len);

		SD_LOG_RDY = 0;
	}

	if(TELEMETRY_RDY) {
		HAL_GPIO_TogglePin(LED_GPIO_Port, LED_Pin);

		char s[150] = {0};
		sprintf(s, "%ld,%.2f,%.2f,%.2f,%.2f,%.2f,%d\n", HAL_GetTick(), v.x, v.y, v.z, temp, pressure, tof_meas);
		uint8_t len = strlen(s);
		HAL_UART_Transmit_DMA(&huart6, (const uint8_t*)s, len);
		TELEMETRY_RDY = 0;
	}


	AssignOutputs(SELENOID_STATES);

  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 12;
  RCC_OscInitStruct.PLL.PLLN = 96;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 5;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_3) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */
int __io_putchar(int ch) {
    ITM_SendChar(ch);
    return ch;
}


void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
  static uint8_t Counter_10ms = 1;
  static uint32_t main_counter = 0;

  if (htim == &htim4 ){

	  IMU_DTRDY = 1;

	  if (Counter_10ms == 20) {
		  TELEMETRY_RDY = 1;
	  }

	  if (Counter_10ms == 50) {
		  SD_LOG_RDY = 1;
	  }

	  if (Counter_10ms == 100) {
		  BATTERY_RDY   = 1;
		  SD_LOG_RDY = 1;
		  Counter_10ms = 0;
	  }

	  if((!MAIN_THRST_LOCK) && (MAIN_THRST_ACTIVATE == GPIO_PIN_RESET)) {
		  main_counter++;
		  if(main_counter == MAIN_SELENOID_TIMEOUT){	// 1 sec, only once
			  MAIN_THRST_ACTIVATE = GPIO_PIN_SET;
			  MAIN_THRST_LOCK = 1;
		  }
	  }

	  Counter_10ms++;

  }
}

void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
{
  if(GPIO_Pin == Contact_Pin) {
	  MAIN_THRST_ACTIVATE = GPIO_PIN_RESET;
  }

}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
