#line 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\pid.h"
#include <Arduino.h>

extern void motorkontrol(int sol, int sag);
extern int hata;
extern float Kp, Kd, Ki;
extern int integral, sonhata, sagmotorpwm, solmotorpwm;


void pid(){
    integral += hata;
    if (abs(hata) < 1000) integral = 0;
    int duzeltmehizi = Kp * hata + Kd * (hata - sonhata) + Ki * integral;
    sonhata = hata;
    sagmotorpwm = 175 + 1.3*duzeltmehizi;
    solmotorpwm = 175 - 1.3*duzeltmehizi;
    sagmotorpwm = constrain(sagmotorpwm, -55, 255);
    solmotorpwm = constrain(solmotorpwm, -55, 255);
    motorkontrol(solmotorpwm, 0.8*sagmotorpwm);
    }
 