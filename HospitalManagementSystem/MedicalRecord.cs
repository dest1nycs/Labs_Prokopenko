using System;


namespace HospitalManagementSystem
{
    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }


        public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
        {
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
            Date = date;
            Description = description ?? string.Empty;
        }


        // parameterless constructor for tests
        public MedicalRecord() { }
    }
}
