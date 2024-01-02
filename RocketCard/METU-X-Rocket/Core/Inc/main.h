/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
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

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
#define LED_Pin GPIO_PIN_13
#define LED_GPIO_Port GPIOC
#define Contact_Pin GPIO_PIN_0
#define Contact_GPIO_Port GPIOA
#define Contact_EXTI_IRQn EXTI0_IRQn
#define Safety_Pin GPIO_PIN_1
#define Safety_GPIO_Port GPIOA
#define OPENSD_TX_Pin GPIO_PIN_2
#define OPENSD_TX_GPIO_Port GPIOA
#define OPENSD_RX_Pin GPIO_PIN_3
#define OPENSD_RX_GPIO_Port GPIOA
#define Main_selenoid_Pin GPIO_PIN_4
#define Main_selenoid_GPIO_Port GPIOA
#define Selenoid_1_Pin GPIO_PIN_5
#define Selenoid_1_GPIO_Port GPIOA
#define Selenoid_2_Pin GPIO_PIN_7
#define Selenoid_2_GPIO_Port GPIOA
#define Selenoid_3_Pin GPIO_PIN_0
#define Selenoid_3_GPIO_Port GPIOB
#define Selenoid_4_Pin GPIO_PIN_1
#define Selenoid_4_GPIO_Port GPIOB
#define MS5611_SCL_Pin GPIO_PIN_8
#define MS5611_SCL_GPIO_Port GPIOA
#define TOF_TX_Pin GPIO_PIN_9
#define TOF_TX_GPIO_Port GPIOA
#define TOF_RX_Pin GPIO_PIN_10
#define TOF_RX_GPIO_Port GPIOA
#define APC220_RX_Pin GPIO_PIN_11
#define APC220_RX_GPIO_Port GPIOA
#define APC220_TX_Pin GPIO_PIN_12
#define APC220_TX_GPIO_Port GPIOA
#define APC220_SET_Pin GPIO_PIN_3
#define APC220_SET_GPIO_Port GPIOB
#define MS5611_SDA_Pin GPIO_PIN_4
#define MS5611_SDA_GPIO_Port GPIOB
#define BNO055_SCL_Pin GPIO_PIN_8
#define BNO055_SCL_GPIO_Port GPIOB
#define BNO055_SDA_Pin GPIO_PIN_9
#define BNO055_SDA_GPIO_Port GPIOB
/* USER CODE BEGIN Private defines */

/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */
