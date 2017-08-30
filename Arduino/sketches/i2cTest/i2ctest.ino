#include <Wire.h>  

void setup() {
  Wire.begin(0x40);                // join i2c bus with address #8
  Wire.onReceive(receiveEvent); // register event
  
  pinMode(LED_BUILTIN, OUTPUT);
  
  Serial.begin(9600);           // start serial for output
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);
  delay(500);
  Wire.write("Hello Raspberry pi!");
  digitalWrite(LED_BUILTIN, LOW);
  delay(500);
}

// function that executes whenever data is received from master
// this function is registered as an event, see setup()
void receiveEvent(int howMany) {
  while (Wire.available() > 0) { // loop through all but the last
    char c = Wire.read(); // receive byte as a character
    Serial.print(c);         // print the character
  }
  Serial.println("");
}
