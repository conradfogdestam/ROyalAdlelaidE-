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
            Random rd = new Random();
            int chance = rd.Next(2);
            if (chance == 1)
            {
                hospital.hospitalPatients.Remove(operationSubject);
                Console.WriteLine($"Oh no!! {operationSubject.name} died of death.\nTime of death: {DateTime.Now}\n");
            }
            else
            {
                Console.WriteLine($"Yaaay!! {operationSubject.name} Survived!!\n");

            }
            
        }
    }
}
