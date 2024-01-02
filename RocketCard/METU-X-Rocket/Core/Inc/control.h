/*
 * control.h
 *
 *  Created on: 28 Jan 2023
 *      Author: atabe
 */

#ifndef INC_CONTROL_H_
#define INC_CONTROL_H_

#include <stdio.h>

#define ROLL_MAX_ANGLE_LIMIT 1.5 // Degrees
#define ROLL_MIN_ANGLE_LIMIT -1.5 // Degrees
#define PITCH_MAX_ANGLE_LIMIT 1.5 // Degrees
#define PITCH_MIN_ANGLE_LIMIT -1.5 // Degrees

typedef struct __SELENOID_STATES {
	volatile uint8_t Selenoid_1:1;
	volatile uint8_t Selenoid_2:1;
	volatile uint8_t Selenoid_3:1;
	volatile uint8_t Selenoid_4:1;
	uint8_t __UNUSED:4;
} __SELENOID_STATES;

extern __SELENOID_STATES SELENOID_STATES;

void Control(__SELENOID_STATES* SELENOID_STATES, float roll, float pitch);
void AssignOutputs(__SELENOID_STATES SELENOID_STATES);

#endif /* INC_CONTROL_H_ */
