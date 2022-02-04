using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalAdelaide
{
    class administrator : employee
    {
        public void assignDoctorToPatient(patient _patient, doctor _doctor)
        {
            _patient.assignedDoctor = _doctor.name;
        }
        public void releasePatient(patient _patient)
        {
            if (hospital.hospitalPatients.Contains(_patient))
            {
                Console.WriteLine($"{_patient.name} got well and was released");
                Console.WriteLine($"Time of release: {DateTime.Now}\n");
                hospital.hospitalPatients.Remove(_patient);
            }   else
            {
                Console.WriteLine($"{_patient.name} is not a current patient at this hospital\n");
            }
             
        }
        public void checkPatientsBills(patient _patient)
        {
            Console.WriteLine($"{_patient.name}'s bills");
            foreach (var bill in _patient.patientbills)
            {
                Console.WriteLine(bill.amount);
            }
            Console.WriteLine("\n");
        }
        public void printAllCurrentPatients()
        {
            Console.WriteLine("All current patients\n--------------");
            foreach (var patient in hospital.hospitalPatients)
            {
                Console.WriteLine($"Name: {patient.name}\nPatient ID: {patient.patientId}");
            }
            Console.WriteLine("\n");
        }
        public void patientInfo(patient _patient)
        {
            Console.WriteLine("Patient's Info\n--------------");
            Console.WriteLine($"Name: {_patient.name}\nID: {_patient.patientId}");
            Console.WriteLine($"Assigned doctor: {_patient.assignedDoctor}\n");
            checkPatientsBills(_patient);
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
