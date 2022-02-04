using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class patientVitals
    {
        public int bpm { get; set; }
        public int bodyTemp { get; set; }
        public int bloodPressure { get; set; }

        public void printVitals()
        {
            Console.WriteLine($"BPM: {bpm}\nBody Temp: {bodyTemp}\nBlood Pressure: {bloodPressure}mmHg\n");
        }
    }
}
