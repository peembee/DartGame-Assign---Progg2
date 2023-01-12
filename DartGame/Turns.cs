using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame
{
    internal class Turns
    {
        private int dartPilOne; 
        private int dartPilTwo;
        private int dartPilThree;
        public Turns(int dartPilOne, int dartPilTwo, int dartPilThree)
        {
            this.dartPilOne = dartPilOne;
            this.dartPilTwo = dartPilTwo;
            this.dartPilThree = dartPilThree;
        }
        public int GetScore ()  
        {
            return dartPilOne + dartPilTwo + dartPilThree;
        }
        public int HighestHit()
        {
            int highestHit = dartPilOne;
            if (highestHit < dartPilTwo) { highestHit = dartPilTwo; }
            else if (highestHit < dartPilThree) { highestHit = dartPilThree; }
            return highestHit;
        }
        public void PrintRounds()
        {
            Console.WriteLine("First Dart: " + dartPilOne + " . Second Dart: " + dartPilTwo + " . Third Dart: " + dartPilThree + " = " + (dartPilOne + dartPilTwo + dartPilThree) + " Points");
        }
    }
}
