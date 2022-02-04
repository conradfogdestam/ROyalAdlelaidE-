using System;

namespace RoyalAdelaide
{
    class Program
    {
        static void Main(string[] args)
        {
            administrator admin1 = new administrator("admin1");
            patient patient1 = new patient("patient1");
            patient patient2 = new patient("patient2");
            doctor doctor1 = new doctor("doctor1");
            nurse nurse1 = new nurse("nurse1");

            patient1.vitals.bloodPressure = 80;
            patient1.vitals.bodyTemp = 37;
            patient1.vitals.bpm = 93;
            patient2.vitals.bpm = 87;
            patient2.vitals.bloodPressure = 76;
            patient2.vitals.bodyTemp = 39;

            admin1.billPatient(patient1, 30000, "operation bill");

            hospital.hospitalPatients.Add(patient1);
            hospital.hospitalPatients.Add(patient2);

            nurse1.checkVitals(patient1);
            doctor1.operation(patient1);

            admin1.checkPatientsBills(patient1);
            admin1.printAllCurrentPatients();
            admin1.releasePatient(patient1);
            admin1.printAllCurrentPatients();
            admin1.patientInfo(patient2);
        }
    }
}
