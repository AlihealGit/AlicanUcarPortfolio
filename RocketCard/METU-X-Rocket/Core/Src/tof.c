/*
 * tof.c
 *
 *  Created on: Feb 20, 2023
 *      Author: atabe
 */

#include "tof.h"

volatile uint8_t TOF_RX_Buffer[9];
volatile uint8_t rx_sync = 0;
volatile uint16_t tof_meas = 9999;

void TOF_UART_Error_Callback(struct __UART_HandleTypeDef *huart){
	__HAL_UART_CLEAR_PEFLAG(huart);
	HAL_UART_DMAStop(huart);
	HAL_UART_MspDeInit(huart);
	HAL_UART_MspInit(huart);

	printf("Sensor UART Error %ld DMA RX/TX error 0x%lx-0x%lx \r\n", HAL_UART_GetError(huart), HAL_DMA_GetError(huart->hdmarx), HAL_DMA_GetError(huart->hdmatx));
	rx_sync = 0;
	tof_meas = 9999;
	while(HAL_UART_Receive_DMA(huart, (uint8_t*) &TOF_RX_Buffer[0], 1) != HAL_OK);
}

void TOF_UART_RxComplete_Callback(struct __UART_HandleTypeDef *huart){
	if(!rx_sync) {
		rx_sync = TOF_RX_Buffer[0] == SENSOR_HEADER;
		if(!rx_sync) {
			while(HAL_UART_Receive_DMA(huart, (uint8_t *) &TOF_RX_Buffer[0], 1) != HAL_OK);
		} else {
			while(HAL_UART_Receive_DMA(huart, (uint8_t *) &TOF_RX_Buffer[1], 8) != HAL_OK);
		}
		return;
	} else {
		rx_sync = TOF_RX_Buffer[0] == SENSOR_HEADER;
		rx_sync = rx_sync && TOF_RX_Buffer[1] == SENSOR_HEADER;
		if(!rx_sync) {
			while(HAL_UART_Receive_DMA(huart, (uint8_t *) &TOF_RX_Buffer[0], 1) != HAL_OK);
			return;
		}

		tof_meas = (uint16_t) (TOF_RX_Buffer[3]<<8 | TOF_RX_Buffer[2]);

		while(HAL_UART_Transmit_DMA(huart, (uint8_t *) TOF_RX_Buffer, 9) != HAL_OK);
		return;
	}
}

void TOF_UART_Init(UART_HandleTypeDef *huart) {
	  HAL_UART_RegisterCallback(huart, HAL_UART_RX_COMPLETE_CB_ID, TOF_UART_RxComplete_Callback);
	  HAL_UART_RegisterCallback(huart, HAL_UART_ERROR_CB_ID, TOF_UART_Error_Callback);
	  HAL_UART_Receive_DMA(huart, (uint8_t*) &TOF_RX_Buffer[0], 1);
}
