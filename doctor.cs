using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class doctor : employee
    {
        public doctor(string _name)
        {
            name = _name;
        }
        public void operation(patient operationSubject)
        {
            if (hospital.hospitalPatients.Contains(operationSubject))
            {
                Random rd = new Random();
                int chance = rd.Next(2);
                if (chance == 1)
                {
                    hospital.hospitalPatients.Remove(operationSubject);
                    Console.WriteLine($"Oh no!! {operationSubject.name} died in surgery.\nTime of death: {DateTime.Now}");
                }
                else
                {
                    Console.WriteLine($"{operationSubject.name} survived the surgery and will make a full recovery!!\n");

                }
            }
            else
            {
                Console.WriteLine("Patient does not exist");
            }

        }
    }
}
