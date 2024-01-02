/*
 * tof.h
 *
 *  Created on: Feb 20, 2023
 *      Author: atabe
 */

#ifndef INC_TOF_H_
#define INC_TOF_H_

#include "main.h"
#include "stdio.h"

#define SENSOR_HEADER 0x59

extern volatile uint16_t tof_meas;

void TOF_UART_Error_Callback(struct __UART_HandleTypeDef *huart);
void TOF_UART_RxComplete_Callback(struct __UART_HandleTypeDef *huart);
void TOF_UART_Init(UART_HandleTypeDef *huart);

#endif /* INC_TOF_H_ */
