#include <Adafruit_NeoPixel.h>
#include <Wire.h>

#define SUB1_PIN 13
#define LED_COUNT 30
#define SUB1_STRIP_COUNT 1

Adafruit_NeoPixel ledStrip = Adafruit_NeoPixel(SUB1_STRIP_COUNT * LED_COUNT, SUB1_PIN, NEO_GRB + NEO_KHZ800);

void setup() {
  Wire.begin(0x40);
  Wire.onReceive(receiveEvent);

  ledStrip.begin();
  ledStrip.setBrightness(255);

  Serial.begin(9600);
}

void loop() {
}

void receiveEvent(int howMany) {
  byte red = Wire.read();
  byte green = Wire.read();
  byte blue = Wire.read();

  for(unsigned int i = 0; i < ledStrip.numPixels(); i++) {
    ledStrip.setPixelColor(i, red, green, blue);
  }
  ledStrip.show();
}

