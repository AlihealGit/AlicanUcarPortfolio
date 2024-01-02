#include "control.h"
#include "main.h"

__SELENOID_STATES SELENOID_STATES = {0};
extern volatile uint8_t MAIN_THRST_ACTIVATE;

void Control(__SELENOID_STATES* SELENOID_STATES, float roll, float pitch) {

	SELENOID_STATES->Selenoid_1 = 0;
	SELENOID_STATES->Selenoid_2 = 0;
	SELENOID_STATES->Selenoid_3 = 0;
	SELENOID_STATES->Selenoid_4 = 0;

	if (roll > ROLL_MAX_ANGLE_LIMIT)	// Sağ-sol
		SELENOID_STATES->Selenoid_1 = 1;
	else if (roll < ROLL_MIN_ANGLE_LIMIT)
		SELENOID_STATES->Selenoid_3 = 1;

	if (pitch > PITCH_MAX_ANGLE_LIMIT)
		SELENOID_STATES->Selenoid_2 = 1;
	else if (pitch < PITCH_MIN_ANGLE_LIMIT)
		SELENOID_STATES->Selenoid_4 = 1;
}

void AssignOutputs(__SELENOID_STATES SELENOID_STATES) {
	HAL_GPIO_WritePin(Selenoid_1_GPIO_Port, Selenoid_1_Pin, SELENOID_STATES.Selenoid_1);
	HAL_GPIO_WritePin(Selenoid_2_GPIO_Port, Selenoid_2_Pin, SELENOID_STATES.Selenoid_2);
	HAL_GPIO_WritePin(Selenoid_3_GPIO_Port, Selenoid_3_Pin, SELENOID_STATES.Selenoid_3);
	HAL_GPIO_WritePin(Selenoid_4_GPIO_Port, Selenoid_4_Pin, SELENOID_STATES.Selenoid_4);
	HAL_GPIO_WritePin(Main_selenoid_GPIO_Port, Main_selenoid_Pin, MAIN_THRST_ACTIVATE);
}
