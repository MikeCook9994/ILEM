#include <Wire.h>  

#define SLAVE_ADDRESS 0x40   // Define the i2c address

void setup()
{
    Serial.begin(9600);
    Wire.begin(SLAVE_ADDRESS); 
}

void loop()
{
    
}
