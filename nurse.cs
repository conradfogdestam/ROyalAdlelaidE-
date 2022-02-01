using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class nurse : employee
    {
        public nurse(string _name)
        {
            name = _name;
        }
        public void checkVitals(patient patientToCheckVitalsOf)
        {
            patientToCheckVitalsOf.vitals.printVitals();
        }
    }
}
