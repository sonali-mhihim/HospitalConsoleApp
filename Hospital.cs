using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalConsoleApp
{
    static class Hospital
    {
        private static List<PatientRegistration> patientRegistrations = new List<PatientRegistration>();
        private static List<Appointment> Appointments = new List<Appointment>();


        //private static HospitalContext db = new HospitalContext();


        /// <summary>
        /// register patient at the Hospital
        /// </summary>
        /// <param name="patientName"> name of the Patient</param>
        /// <param name="Address"> address of the patient</param>
        /// <param name="insuranceDetails"> Insurance deatails of the patient</param>
        /// <returns></returns>
        public static PatientRegistration RegisterPatient(string patientName, string Address, string insuranceDetails)
        {
            var patientRegistration = new PatientRegistration
            {
                PatientName = patientName,
                Address = Address,
                InsuranceDetails = insuranceDetails
            };
            patientRegistrations.Add(patientRegistration);

            //db.patientRegistrations.Add(patientRegistration);
            //db.SaveChanges();
            return patientRegistration;
        }

        public static IEnumerable<PatientRegistration> GetPatientRegistrations(string Address)
        {
            return patientRegistrations.Where(patientRegistrations => patientRegistrations.Address == Address);

        }
        public static IEnumerable<Appointment> GetAppointmentsByMedicalRecordNumber(int MedicalRecordNumber)
        {
            return Appointments.Where(a => a.medicalRecordNumber == MedicalRecordNumber).OrderByDescending(a => a.AppointmentDate);
        }

        public static bool IsComplete(int MedicalRecordNumber)
        {
            bool complete = true;
            return complete;
        }

        public static Appointment ScheduleAppointment(DateTime AppointmnetDate, int MedicalRecordNumber, string providerName, TypeofAppointments appointmentType)
        {
            //Locate the patientRegistration
            //LINQ
            var PatientRegistration = patientRegistrations.SingleOrDefault(PatientRegistration => PatientRegistration.MedicalRecordNumber == MedicalRecordNumber);

            //Schedule appointment of the patient
            if (PatientRegistration != null)
            {
                //add a Appointment
                var appointment = new Appointment
                {
                    AppointmentType = appointmentType
                };
                appointment.ScheduleAppointment(AppointmnetDate, providerName, PatientRegistration.PatientName, PatientRegistration.MedicalRecordNumber);
                Appointments.Add(appointment);


                //db.SaveChanges();

                return appointment;
            }
            else
            {
                Console.WriteLine($"patient with MedicalRecordNumber= {MedicalRecordNumber} not found");
                return null;
            }
        }
        public static Appointment ModifyAppointment(DateTime appointmnetDate, int MedicalRecordNumber)
        {
            //Locate the patientRegistration
            //LINQ
            var PatientRegistration = patientRegistrations.SingleOrDefault(PatientRegistration => PatientRegistration.MedicalRecordNumber == MedicalRecordNumber);

            //Modify appointment of the patient
            if (PatientRegistration != null)
            {
                var existingAppointment = GetAppointmentsByMedicalRecordNumber(MedicalRecordNumber).SingleOrDefault();
                if (existingAppointment != null)
                {
                    existingAppointment.ModifyAppointment(appointmnetDate);

                    //db.SaveChanges();

                    return existingAppointment;
                }
                else
                {
                    Console.WriteLine($"No appointment exists with MedicalRecordNumber= {MedicalRecordNumber}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"patient with MedicalRecordNumber= {MedicalRecordNumber} not found");
                return null;
            }
        }
    }
}
