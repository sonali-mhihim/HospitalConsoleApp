using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalConsoleApp
{

    /// <summary>
    /// This class represent patient registration to get an appointment
    /// </summary>
    class PatientRegistration
    {
        private static int lastMedicalRecordNumber = 0;
        #region properties
        /// <summary>
        /// unique medical record number for each patient
        /// </summary>
        public int MedicalRecordNumber { get; private set; }
        /// <summary>
        /// Name of the patient
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// Age of the patient
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Sex of the patient
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Date of birth of the patient
        /// </summary>
        public int DateOfBirth { get; set; }
        /// <summary>
        /// Email address of the patient
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Mobile number of the patient
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Address of the patient
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Patient's insurance detail includes policy number, policy holder, and type insurance
        /// </summary>
        public string InsuranceDetails { get; set; }
        /// <summary>
        /// patient's medical history includes allergies, any chronic diseases, any medication taking, any past surgery
        /// </summary>
        public string MedicalHistory { get; set; }
        #endregion

        #region Construtors
        public PatientRegistration()
        {
            MedicalRecordNumber = ++lastMedicalRecordNumber;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Checks if the registration information is complete
        /// </summary>
        /// <returns>true if complete else false.</returns>
        public bool IsComplete()
        {
            bool complete = true;

            if (this.PatientName == null)
            {
                // 1. Name is not null.
                complete = false;
            }
            else if (this.Address == null)
            {
                // 2. Address is not null
                complete = false;
            }
            else if (this.InsuranceDetails == null)
            {
                // 3. Insurance deatail is not null
                complete = false;
            }

            return complete;
        }

        #endregion
    }
}