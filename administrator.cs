using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class administrator : employee
    {
        public void releasePatient(patient _patientName)
        {
            Console.WriteLine($"{_patientName.name} got well and was released");
            Console.WriteLine($"Time of release: {DateTime.Now}\n");
            hospital.hospitalPatients.Remove(_patientName);
        }
        public void checkPatientsBills(patient _patientName)
        {
            Console.WriteLine($"{_patientName.name}'s bills");
            foreach (var bill in _patientName.patientbills)
            {
                Console.WriteLine(bill.amount);
            }
            Console.WriteLine("\n");
        }
        public void printAllCurrentPatients()
        {
            foreach (var patient in hospital.hospitalPatients)
            {
                Console.WriteLine($"Name: {patient.name}\nPatient ID: {patient.patientId}");
            }
            Console.WriteLine("\n");
        }
        public void patientInfo(patient _patient)
        {
            Console.WriteLine("Patient's Info\n--------------");
            Console.WriteLine($"Name: {_patient.name}\nID: {_patient.patientId}\n");
            checkPatientsBills(_patient);
            Console.WriteLine("--------------");
            Console.WriteLine("\n");
        }
        public void billPatient(patient _patient, int _amount, string reason)
        {
            bill newBill = new bill(_amount, reason);
            _patient.patientbills.Add(newBill);
        }
        public administrator(string _name)
        {
            name = _name;
        }
    }
}
