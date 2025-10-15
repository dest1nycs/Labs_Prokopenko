using System;


namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }


        public Doctor(int id, string name, string specialization)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
        }


        // parameterless constructor for tests that set properties directly
        public Doctor() { }
    }
}
