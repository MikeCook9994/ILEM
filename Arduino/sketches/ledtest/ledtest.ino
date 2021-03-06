#include <Adafruit_NeoPixel.h>

#define SUB1_PIN 13
//#define SUB2_PIN 10
//#define SUB3_PIN 11

#define LED_COUNT 30

#define SUB1_STRIP_COUNT 1
//#define SUB2_STRIP_COUNT 10
//#define SUB3_STRIP_COUNT 4

int red = 255;
int green = 0;
int blue = 0;

Adafruit_NeoPixel subsection1Strip = Adafruit_NeoPixel(SUB1_STRIP_COUNT * LED_COUNT, SUB1_PIN, NEO_GRB + NEO_KHZ800);
//Adafruit_NeoPixel subsection2Strip = Adafruit_NeoPixel(SUB2_STRIP_COUNT * LED_COUNT, SUB2_PIN, NEO_GRB + NEO_KHZ800);
//Adafruit_NeoPixel subsection3Strip = Adafruit_NeoPixel(SUB3_STRIP_COUNT * LED_COUNT, SUB3_PIN, NEO_GRB + NEO_KHZ800);

void setup() {
  subsection1Strip.begin();
  subsection1Strip.setBrightness(255);

//  subsection2Strip.begin();
//  subsection2Strip.setBrightness(255);
//  
//  subsection3Strip.begin();
//  subsection3Strip.setBrightness(255);
// 
//  for(unsigned int i = 0; i < subsection2Strip.numPixels(); i++) {
//    subsection2Strip.setPixelColor(i, 0, 255, 0);
//  }
//
//  for(unsigned int i = 0; i < subsection3Strip.numPixels(); i++) {
//    subsection3Strip.setPixelColor(i, 0, 0, 255);
//  }

//  subsection2Strip.show();
//  subsection3Strip.show();


}

void loop() {
  for(unsigned int i = 0; i < subsection1Strip.numPixels(); i++) {
    subsection1Strip.setPixelColor(i, red, green, blue);
  }
  subsection1Strip.show();

  if(red > 0 && blue == 0) {
    red--;
    green++;
  }
  else if(red == 0 && green > 0){
    green--;
    blue++;
  }
  else if(green == 0 && blue > 0) {
    blue--;
    red++;
  }
  
  delay(10);
}

