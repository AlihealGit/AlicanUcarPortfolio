#line 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\specal_cases.h"
 #include <Arduino.h>

    extern int hata;
    extern boolean dsensors[];
    extern void sensoroku();
    extern void motorkontrol(int sol, int sag);

void sol_sag_90(){
  int sol = 0;
  int sag = 0;
  sol = dsensors[6]+dsensors[7]+dsensors[8]+dsensors[9]+dsensors[10]+dsensors[11]+dsensors[12];
  sag = dsensors[0] + dsensors[1] + dsensors[2] + dsensors[3] + dsensors[4] + dsensors[5] + dsensors[6];
  if (sol >= 5){
    motorkontrol(150,150); delay(40);
    do {sensoroku(); motorkontrol(-55,250);}
      while(abs(hata) >= 2500);
  }
  if (sag >= 5){
    motorkontrol(150,150); delay(40);
    do {sensoroku(); motorkontrol(250,-55);}
      while(abs(hata) >= 2500);
  }
}