# 1 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino"
# 2 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2
# 3 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2

# 5 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2

# 7 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2
# 8 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2
# 9 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2
# 10 "c:\\Users\\alica\\Documents\\230104-162745-pico\\src\\cizgi_izleyen.ino" 2

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
