#line 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\global_variables.h"
#include "RP2040_PWM.h"
#include <Arduino.h>
#include <QTRSensors.h>

    RP2040_PWM* PWM_Instance;
    RP2040_PWM* PWM_Instance_2;
    float frequency = 90000;
    int pinToUse_sol = 16;
    int pinToUse_sag = 21;

    QTRSensors qtr;
    const uint8_t SensorCount = 13;
    uint16_t sensorValues[SensorCount];
    boolean dsensors[SensorCount];


    int hata = 0;

    float Kp = 0.03, Kd = 0.5, Ki = 0.000;
    int integral = 0, sonhata = 0, sagmotorpwm = 0, solmotorpwm = 0;
