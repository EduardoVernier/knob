/*
http://arduinotronics.blogspot.ie/2013/09/using-rotary-encoder-with-arduino.html
*/
// usually the rotary encoders three pins have the ground pin in the middle
enum PinAssignments {
  encoderPinA = 2,   // right (labeled DT on our decoder)
  encoderPinB = 3,   // left (labeled CLK on our decoder)
  clearButton = 8    // switch (labeled SW on our decoder)
  // connect the +5v and gnd appropriately
};

volatile int encoderPos = 0;  // a counter for the dial
unsigned int lastReportedPos = 1;   // change management
static boolean rotating=false;      // debounce management
boolean lastButtonState = HIGH;
unsigned long time = 0;
boolean doubleClick = false;

// interrupt service routine vars
boolean A_set = false;
boolean B_set = false;

void setup() {
  pinMode(encoderPinA, INPUT_PULLUP); // new method of enabling pullups
  pinMode(encoderPinB, INPUT_PULLUP);
  pinMode(clearButton, INPUT_PULLUP);
  
  // encoder pin on interrupt 0 (pin 2)
  attachInterrupt(0, doEncoderA, CHANGE);
  // encoder pin on interrupt 1 (pin 3)
  attachInterrupt(1, doEncoderB, CHANGE);
  
  Serial.begin(9600);  // output
}

// main loop, work is done by interrupt service routines, this one only prints stuff
void loop() {
  rotating = true;  // reset the debouncer
  //Serial.print("t");
  if (lastReportedPos != encoderPos) {
    //Serial.print("Index:");
    //Serial.println(encoderPos, DEC);
    lastReportedPos = encoderPos;
  }
  if (digitalRead(clearButton) == LOW && lastButtonState == HIGH)  {
    //encoderPos = 0;
    //Serial.print((char)1);
    lastButtonState = LOW;
    delay(1);
  }
  else if (digitalRead(clearButton) == HIGH && lastButtonState == LOW)
  {
    delay(1);
    time = millis();
    doubleClick = false;
    while (millis() < time+200)
    {
      if (digitalRead(clearButton) == LOW)
      {
        time = millis();
        while(millis() < time+100)
        {
          doubleClick = true;
          break;
        }
      }
    }
    
    if (doubleClick)
      Serial.print((char)5);
    else
      Serial.print((char)4);
    
    //Serial.print((char)4);
    //Serial.print("4");
    Serial.flush();
    lastButtonState = HIGH;
  }
  
}

// Interrupt on A changing state
void doEncoderA(){
  // debounce
  if ( rotating ) delay (1);  // wait a little until the bouncing is done
  // Test transition, did things really change?
  if( digitalRead(encoderPinA) != A_set ) {  // debounce once more
    A_set = !A_set;
    // adjust counter + if A leads B
    if ( A_set && !B_set )
    {
      encoderPos += 1;
      Serial.print((char)1);
    }
    rotating = false;  // no more debouncing until loop() hits again
  }
}

// Interrupt on B changing state, same as A above
void doEncoderB(){
  if ( rotating ) delay (1);
  if( digitalRead(encoderPinB) != B_set ) {
    B_set = !B_set;
    //  adjust counter - 1 if B leads A
    if( B_set && !A_set )
    {
      encoderPos -= 1;
      Serial.print((char)2);
    }
    rotating = false;
  }
}
