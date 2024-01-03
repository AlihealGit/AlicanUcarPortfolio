#line 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\qtrsensor_oku.h"
 #include <Arduino.h>
 #include <QTRSensors.h>
 
 extern QTRSensors qtr;
 extern boolean dsensors[];
 extern uint16_t sensorValues[];
 extern int hata;

void sensoroku(){
  uint16_t position = qtr.readLineBlack(sensorValues);
  hata = position - 6000;
  for (int i = 0; i < 13; i++) {
    if (sensorValues[i] <= 150)
      dsensors[i] = 0;
    else
      dsensors[i] = 1;
  }
}

void sensorlogicprint(){
    for (int i = 0; i < 13; i++) {
      Serial.print(i);
      Serial.print(":");
      Serial.print(dsensors[i]);
      Serial.print(" / ");
  }
  Serial.print("hata:");
  Serial.print(hata);
  Serial.print(" /");
  Serial.println("");
}

void sensorprint(){
  for (int i = 0; i < 13; i++) {
      Serial.print(i);
      Serial.print(":");
      Serial.print(sensorValues[i]);
      Serial.print(" ");
  }
  Serial.println("");
  delay(100);
}