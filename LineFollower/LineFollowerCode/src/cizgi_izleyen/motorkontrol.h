#include <Arduino.h>
#include "RP2040_PWM.h"

    extern RP2040_PWM* PWM_Instance;
    extern RP2040_PWM* PWM_Instance_2;
    extern float frequency;
    extern int pinToUse_sol;
    extern int pinToUse_sag;


void motorkontrol(int sol, int sag) {
  if (sol>0){
    digitalWrite(18, HIGH);
    digitalWrite(17, LOW);
    PWM_Instance->setPWM(pinToUse_sol, frequency, sol/2.55);
  }
  else{
    digitalWrite(18, LOW);
    digitalWrite(17, HIGH);
    PWM_Instance->setPWM(pinToUse_sol, frequency, abs(sol)/2.55);
  }
  if (sag>0){
    digitalWrite(19, HIGH);
    digitalWrite(20, LOW);
    PWM_Instance_2->setPWM(pinToUse_sag, frequency, sag/2.55);
  }
  else {
    digitalWrite(19, LOW);
    digitalWrite(20, HIGH);
    PWM_Instance_2->setPWM(pinToUse_sag, frequency, abs(sag)/2.55);
  }
}
