#include <Arduino.h>
#include "global_variables.h"
#include "RP2040_PWM.h"
#include "motorkontrol.h"
#include <QTRSensors.h>
#include "qtrsensor_oku.h"
#include "specal_cases.h"
#include "pid.h"
#include "setup_functions.h"

void setup() {
  Serial.begin(9600);
  pwm_setup();
  qtr_setup();
}

void loop() {
  sensoroku();
  sol_sag_90();
  pid();
  sensorprint();
}
