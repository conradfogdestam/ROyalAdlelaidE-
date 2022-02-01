using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class bill
    {
        public int amount { get; set; }
        public string description { get; set; }

        public bill(int _amount, string _description)
        {
            amount = _amount;
            description = _description;
        }
    }
}
