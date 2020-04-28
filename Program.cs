using System;

namespace HospitalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to our Hospital!****");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Register patient");
                Console.WriteLine("2. Schedule appointment");
                Console.WriteLine("3. Modify appointment");
                Console.WriteLine("4. Print all patientRegistration");
                Console.WriteLine("5. Print all Appointmnets");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting our Hospital!");
                        return;
                    case "1":
                        Console.Write("Patient Name: ");
                        var patientName = Console.ReadLine();
                        Console.Write("Address: ");
                        var Address = Console.ReadLine();
                        Console.Write("InsuranceDetails: ");
                        var insuranceDetails = Console.ReadLine();

                        var patientRegistration = Hospital.RegisterPatient(patientName, Address, insuranceDetails);
                        Console.WriteLine($"MRN: {patientRegistration.MedicalRecordNumber}, Name: {patientRegistration.PatientName}, Address: {patientRegistration.Address}, ID: {patientRegistration.InsuranceDetails}");

                        break;

                    case "2":
                        PrintAllPatientRegistrations();
                        Console.Write("MedicalRecordNumber:");
                        var medicalRecordNumber = Convert.ToInt32( Console.ReadLine());
                        Console.Write("Provider Name: ");
                        var providerName = Console.ReadLine();
                        Console.Write("AppointmentDate:");
                        var appointmentDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Appointment Type");
                        var appointmentTypes = Enum.GetNames(typeof(TypeofAppointments));
                        for (var i=0; i< appointmentTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{appointmentTypes[i]}");
                        }
                        var appointmentType = Enum.Parse< TypeofAppointments >( Console.ReadLine());

                        var appointment = Hospital.ScheduleAppointment(appointmentDate, medicalRecordNumber, providerName,appointmentType);
                        Console.WriteLine($"PN:{appointment.ProviderName}, AD:{appointment.AppointmentDate}, AT:{appointment.AppointmentType}");
                        Console.WriteLine("Appointment successfully scheduled!");
                        break;
                    case "3":
                        PrintAllPatientRegistrations();
                        Console.Write("MedicalRecordNumber: ");
                        medicalRecordNumber = Convert.ToInt32 (Console.ReadLine());
                        Console.Write("AppointmentDate: ");
                        appointmentDate = Convert.ToDateTime(Console.ReadLine());  

                        appointment = Hospital.ModifyAppointment(appointmentDate, medicalRecordNumber);
                        Console.WriteLine($"Appointment successfully Modified! New Date = {appointment.AppointmentDate} ");
                        break;
                    case "4":
                        PrintAllPatientRegistrations();
                        break;
                    case "5":
                        PrintAllPatientRegistrations();
                        Console.Write("MedicalRecordNumber:");
                        medicalRecordNumber = Convert.ToInt32(Console.ReadLine());
                        var appointments = Hospital.GetAppointmentsByMedicalRecordNumber(medicalRecordNumber);
                        foreach (var Appointment in appointments)
                        {
                            Console.WriteLine($"MRN:{Appointment.medicalRecordNumber}, Name: {Appointment.PatientName}, PN: {Appointment.ProviderName}, AD:{Appointment.AppointmentDate}, AT:{Appointment.AppointmentType}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private static void PrintAllPatientRegistrations()
        {
            Console.Write("Address: ");
            var Address = Console.ReadLine();
            var patientRegistrations = Hospital.GetPatientRegistrations(Address);
            foreach (var PR in patientRegistrations)
            {
                Console.WriteLine($"MRN: {PR.MedicalRecordNumber}, Name: {PR.PatientName}, Address: {PR.Address}, ID: {PR.InsuranceDetails}");
            }
        }
    }
}
