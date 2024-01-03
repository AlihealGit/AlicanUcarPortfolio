#include <Arduino.h>
#include "RP2040_PWM.h"
#include "motorkontrol.h"
#include <QTRSensors.h>
#include "qtrsensor_oku.h"

    RP2040_PWM* PWM_Instance;
    RP2040_PWM* PWM_Instance_2;
    float frequency = 80000;
    int pinToUse_sol = 16;
    int pinToUse_sag = 21;

    QTRSensors qtr;
    const uint8_t SensorCount = 13;
    uint16_t sensorValues[SensorCount];
    boolean dsensors[SensorCount];


    int hata = 0;

void pwm_setup(){
  pinMode(17, OUTPUT);  //INA2
  pinMode(18, OUTPUT);  //INA1
  pinMode(19, OUTPUT);  //INB1
  pinMode(20, OUTPUT);  //INB2
  PWM_Instance = new RP2040_PWM(pinToUse_sol, frequency, 0);
  PWM_Instance_2 = new RP2040_PWM(pinToUse_sag, frequency, 0);
}
void qtr_setup(){
  pinMode(LED_BUILTIN,OUTPUT);
  qtr.setTypeRC();
  qtr.setSensorPins((const uint8_t[]){ 0, 1, 2, 3, 4, 5, 6, 7, 15, 9, 10, 11, 12 }, SensorCount);
  digitalWrite(LED_BUILTIN, HIGH);
    for (uint16_t i = 0; i < 400; i++) {
      qtr.calibrate();
      Serial.println("calibrating");
  }
  digitalWrite(LED_BUILTIN, LOW);
  delay(500);
}

void setup() {
  Serial.begin(9600);
  pwm_setup();
  qtr_setup();
}

void loop() {
  sensoroku();
  sensorlogicprint();
}
