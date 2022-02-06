using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoyalAdelaide
{
    class administrator : employee
    {
        public void fireStaff()
        {
            Console.Write("Department to fire from\n1) Nurse\n2) Doctor\nSelect: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Choose Nurse to fire:");
                foreach (var nurse in hospital.hospitalNurses)
                {
                    Console.WriteLine($"{hospital.hospitalNurses.IndexOf(nurse)}) {nurse.name}");
                }
                Console.Write("\nSelect: ");
                int chosen = int.Parse(Console.ReadLine());
                hospital.hospitalNurses.Remove(hospital.hospitalNurses.ElementAt(chosen));
                Console.WriteLine($"Successfully fired nurse!!");
                Thread.Sleep(2000);
            }
            if (choice == 2)
            {
                Console.WriteLine("Choose Doctor to fire:");
                foreach (var doctor in hospital.hospitalDoctors)
                {
                    Console.WriteLine($"{hospital.hospitalDoctors.IndexOf(doctor)}) {doctor.name}");
                }
                Console.Write("\nSelect: ");
                int chosen = int.Parse(Console.ReadLine());
                hospital.hospitalDoctors.Remove(hospital.hospitalDoctors.ElementAt(chosen));
                Console.WriteLine($"Successfully fired doctor!!");
                Thread.Sleep(2000);
            }
        }
        public void hireStaff()
        {
            Console.Write("Hire...\n1) Nurse\n2) Doctor");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("enter name of new staff");
            var name = Convert.ToString(Console.ReadLine());
            if (choice == 1)
            {
                dynamic nurse = new nurse(name);
                hospital.hospitalNurses.Add(nurse);
                Console.WriteLine($"Added {nurse.name} to doctor staff! Id {nurse.employeeId}");
                Thread.Sleep(2000);
            }
            if (choice == 2)
            {
                dynamic doctor = new doctor(name);
                hospital.hospitalDoctors.Add(doctor);
                Console.WriteLine($"Added {doctor.name} to doctor staff! id {doctor.employeeId}");
                Thread.Sleep(2000);
            }
        }
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
            if (_patient.patientbills.Count.Equals(0))
            {
                Console.WriteLine($"It appears {_patient.name} is not in debt\n");
            }
            else
            {
                Console.WriteLine($"{_patient.name}'s bills: ");
                foreach (var bill in _patient.patientbills)
                {
                    Console.WriteLine(bill.amount);
                }
                Console.WriteLine("\n");
            }
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
        public void billPatient(patient _patient, int _amount, string chargedFor)
        {
            bill newBill = new bill(_amount, chargedFor);
            _patient.patientbills.Add(newBill);
            Console.WriteLine($"{_patient.name} charged ${_amount} for {chargedFor}");
        }
        public administrator(string _name)
        {
            name = _name;
        }
    }
}
