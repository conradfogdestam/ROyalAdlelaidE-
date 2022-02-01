using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class employee
    {
        public string name { get; set; }
        public Guid employeeId { get; set; }

        public employee()
        {
            employeeId = Guid.NewGuid();
        }
    }
}
