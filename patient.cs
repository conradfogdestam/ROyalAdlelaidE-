using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class patient
    {
        public string name { get; set; }
        public Guid patientId { get; set; }
        public string assignedDoctor { get; set; }
        public List<bill> patientbills { get; set; }
        public patientVitals vitals { get; set; }

        public patient(string _name)
        {
            patientbills = new List<bill>();
            vitals = new patientVitals();
            patientId = Guid.NewGuid();
            name = _name;
        }
    }
}
