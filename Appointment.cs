using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace HospitalConsoleApp
{
    enum TypeofAppointments
    {
        Primarycare,
        Specialitycare,
        Laboratory,
        DiagnosticImaging
    }


    /// <summary>
    /// This class represent appointment to recieve disparate services
    /// </summary>
    class Appointment
    {
        #region properties
        /// <summary>
        /// Name of the patient
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// Provider Name
        /// </summary>
        public string ProviderName { get; private set; }
        /// <summary>
        /// Appointmnet date and time
        /// </summary>
        public DateTime AppointmentDate { get; private set; }
        /// <summary>
        /// Appointment for What of service?
        /// </summary>
        public TypeofAppointments AppointmentType { get; set; }

        public string AppointmentId { get; private set; }
        public int medicalRecordNumber { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Schedule appointment to recieve  medical services
        /// </summary>
        /// <param name="createDate">appointment date and time</param>
        /// <param name="providerName">appointment with provider</param>
        /// <param name="patientName"> Name of patient having appointment</param>
        public void ScheduleAppointment(DateTime createDate, string providerName, string patientName,int medicalRecordNumber)
        {
            this.AppointmentDate = createDate;
            this.ProviderName = providerName;
            this.PatientName = patientName;
            this.medicalRecordNumber = medicalRecordNumber;
        }
        /// <summary>
        /// Modify appointment due to unanticipated events
        /// </summary>
        /// <param name="newDate">prepone or postpone appointment</param>
        public void ModifyAppointment(DateTime newDate)
        {
            this.AppointmentDate = newDate;

        }
        /// <summary>
        /// cancel appointment as no longer needed
        /// </summary>
        /// <param name="providerName">appointment with provider</param>
        /// <param name="patientName">name of the patient cancelling appointment</param>
        public void CancelAppointment()
        {
            this.ProviderName = null;
            this.AppointmentDate = DateTime.MinValue;

        }

        #endregion
    }
}
