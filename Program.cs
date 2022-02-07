using System;
using System.Linq;
using System.Threading;

namespace RoyalAdelaide
{
    class Program
    {
        public static int choosePatient()
        {
            foreach (var patient in hospital.hospitalPatients)
            {
                Console.WriteLine($"{hospital.hospitalPatients.IndexOf(patient)}) {patient.name}");
            }
            Console.Write("Select: ");
            return int.Parse(Console.ReadLine());
        }
        public static int chooseDoctor()
        {
            foreach (var doctor in hospital.hospitalDoctors)
            {
                Console.WriteLine($"{hospital.hospitalDoctors.IndexOf(doctor)}) {doctor.name}");
            }
            Console.Write("\nSelect: ");
            return int.Parse(Console.ReadLine());
        }
        public static int chooseNurse()
        {
            foreach (var nurse in hospital.hospitalNurses)
            {
                Console.WriteLine($"{hospital.hospitalNurses.IndexOf(nurse)}) {nurse.name}");
            }
            Console.Write("\nSelect: ");
            return int.Parse(Console.ReadLine());
        }


        static void Main(string[] args)
        {
            administrator admin1 = new administrator("admin1");
            hospital.hospitalAdministrators.Add(admin1);

            patient patient1 = new patient("patient1");
            patient patient2 = new patient("patient2");
            doctor doctor1 = new doctor("doctor1");
            nurse nurse1 = new nurse("nurse1");
            hospital.hospitalNurses.Add(nurse1);
            hospital.hospitalDoctors.Add(doctor1);
            hospital.hospitalPatients.Add(patient1);
            hospital.hospitalPatients.Add(patient2);

            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("ROYAL ADELAIDE HOSPITAL");
                Console.Write("Log in as: \n1) Nurse\n2) Doctor\n3) Administrator\n4) Exit\nSelect(1-4): ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 1)
                {
                    Console.WriteLine("Log in as...");
                    loggedInAsNurse(hospital.hospitalNurses.ElementAt(chooseNurse()));
                }

                if (choice == 2)
                {
                    Console.WriteLine("Log in as...");
                    loggedInAsDoctor(hospital.hospitalDoctors.ElementAt(chooseDoctor()));
                }
                if (choice == 3)
                {
                    Console.WriteLine("Log in as...");
                    foreach (var admin in hospital.hospitalAdministrators)
                    {
                        Console.Write($"{hospital.hospitalAdministrators.IndexOf(admin)}) {admin.name}");
                    }
                    Console.Write("\nSelect: ");
                    int adminChoice = int.Parse(Console.ReadLine());
                    loggedInAsAdministrator(hospital.hospitalAdministrators.ElementAt(adminChoice));
                }
                if (choice == 4)
                {
                    inMenu = false;
                }

            }
        }
        public static void loggedInAsNurse(nurse currentNurse)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as {currentNurse.name}");
                Console.Write("Options: \n1) Check vitals of patient\n2) Log out\nSelect: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Choose patient to check vitals of:");
                        currentNurse.checkVitals(hospital.hospitalPatients.ElementAt(choosePatient()));
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("INVALID!!!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
        public static void loggedInAsDoctor(doctor currentDoctor)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as {currentDoctor.name}");
                Console.Write("Options: \n1) Operate\n2) Log out\nSelect: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Choose patient to operate on:");
                        currentDoctor.operation(hospital.hospitalPatients.ElementAt(choosePatient()));
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("INVALID!!!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
        public static void loggedInAsAdministrator(administrator currentAdmin)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.Write($"Logged in as {currentAdmin.name}\nOptions:\n1) Assign doctor to patient\n2) Release patient\n3) Check patient bills\n4) Hospital patients list\n5) Patient info\n6) Bill patient\n7) Add to hospital\n8) Fire staff\n9) Log out\nSelect: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Assign doctor to: ");
                        var patient = hospital.hospitalPatients.ElementAt(choosePatient());
                        Console.WriteLine($"Assign {patient.name} to: ");
                        var doctor = hospital.hospitalDoctors.ElementAt(chooseDoctor());
                        currentAdmin.assignDoctorToPatient(patient, doctor);
                        Console.WriteLine($"Doctor({doctor.name}) assignet to patient({patient.name})");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine("Choose patient to release: ");
                        currentAdmin.releasePatient(hospital.hospitalPatients.ElementAt(choosePatient()));
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine("Check bills of: ");
                        currentAdmin.checkPatientsBills(hospital.hospitalPatients.ElementAt(choosePatient()));
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        currentAdmin.printAllCurrentPatients();
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        currentAdmin.patientInfo(hospital.hospitalPatients.ElementAt(choosePatient()));
                        Thread.Sleep(2000);
                        break;
                    case 6:
                        Console.WriteLine("Choose patient to bill");
                        patient = hospital.hospitalPatients.ElementAt(choosePatient());
                        Console.WriteLine($"Amount to bill {patient.name}");
                        var amount = int.Parse(Console.ReadLine());
                        Console.Write("Billed for: ");
                        string reason = Convert.ToString(Console.ReadLine());
                        currentAdmin.billPatient(patient, amount, reason);
                        Thread.Sleep(2000);
                        break;
                    case 7:
                        currentAdmin.addToHospital();
                        break;
                    case 8:
                        currentAdmin.fireStaff();
                        break;
                    case 9:
                        Console.Clear();
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("INVALID!!!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
