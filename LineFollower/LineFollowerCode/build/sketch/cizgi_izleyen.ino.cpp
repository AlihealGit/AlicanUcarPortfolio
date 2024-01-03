#line 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino"
#include <Arduino.h>
#include "global_variables.h"
#include "RP2040_PWM.h"
#include "motorkontrol.h"
#include <QTRSensors.h>
#include "qtrsensor_oku.h"
#include "specal_cases.h"
#include "pid.h"
#include "setup_functions.h"

#line 11 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino"
void setup();
#line 17 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino"
void loop();
#line 11 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino"
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

