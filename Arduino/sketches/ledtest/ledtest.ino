#include <Adafruit_NeoPixel.h>

#define SUB1_PIN 4
#define SUB2_PIN 3
#define SUB3_PIN 2

#define LED_COUNT 15

#define SUB1_STRIP_COUNT 10
#define SUB2_STRIP_COUNT 10
#define SUB3_STRIP_COUNT 4

Adafruit_NeoPixel subsection1Strip = Adafruit_NeoPixel(SUB1_STRIP_COUNT * LED_COUNT, SUB1_PIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel subsection2Strip = Adafruit_NeoPixel(SUB2_STRIP_COUNT * LED_COUNT, SUB2_PIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel subsection3Strip = Adafruit_NeoPixel(SUB3_STRIP_COUNT * LED_COUNT, SUB3_PIN, NEO_GRB + NEO_KHZ800);

void setup() {
  subsection1Strip.begin();
  subsection1Strip.setBrightness(255);
  
  subsection2Strip.begin();
  subsection2Strip.setBrightness(255);
  
  subsection3Strip.begin();
  subsection3Strip.setBrightness(255);
 

  for(unsigned int i = 0; i < subsection1Strip.numPixels(); i++) {
    subsection1Strip.setPixelColor(i, 255, 0, 0);
  }

  for(unsigned int i = 0; i < subsection2Strip.numPixels(); i++) {
    subsection2Strip.setPixelColor(i, 0, 255, 0);
  }

  for(unsigned int i = 0; i < subsection3Strip.numPixels(); i++) {
    subsection3Strip.setPixelColor(i, 0, 0, 255);
  }

  subsection1Strip.show();
  subsection2Strip.show();
  subsection3Strip.show();
}

void loop() {

}

