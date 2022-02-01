using System;

namespace RoyalAdelaide
{
    class Program
    {
        static void Main(string[] args)
        {
            patient fronx = new patient("fronx");
            patient ddd = new patient("ddd");
            doctor roit = new doctor("roit");

            fronx.vitals.bloodPressure = 80;

            bill newBill = new bill(30, "ddsdasd");
            fronx.patientbills.Add(newBill);
            hospital.hospitalPatients.Add(fronx);
            hospital.hospitalPatients.Add(ddd);
            roit.operation(fronx);
            foreach (var patient in hospital.hospitalPatients)
            {
                Console.WriteLine(patient.name);
                Console.WriteLine(patient.patientId);
                Console.WriteLine(patient.vitals.bloodPressure);

                foreach (var bill in patient.patientbills)
                {
                    Console.WriteLine(bill.amount);
                }
            }


        }
    }
}
