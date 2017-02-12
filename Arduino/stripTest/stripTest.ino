#include <Adafruit_NeoPixel.h>

#define PIN 12
#define PIXEL_COUNT 30
#define STRIP_COUNT 3

Adafruit_NeoPixel strip = Adafruit_NeoPixel(PIXEL_COUNT * STRIP_COUNT, PIN, NEO_GRB + NEO_KHZ800);

void setup() {
  strip.begin();
  strip.setBrightness(50);
  strip.show();
};

void loop() {
  for(unsigned int i = 0; i < strip.numPixels(); i++) {
    if(i == 0) {
      strip.setPixelColor(strip.numPixels() - 1, 0, 0, 0);
    }
    else {
      strip.setPixelColor(i - 1, 0, 0, 0);
    }
    strip.setPixelColor(i, 255, 0, random(255));
    strip.show();
    delay(100);
  }
}

