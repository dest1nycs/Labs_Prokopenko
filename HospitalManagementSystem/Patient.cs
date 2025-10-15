using System;


namespace HospitalManagementSystem
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
        }


        // parameterless constructor for tests that set properties directly
        public Patient() { }
    }
}
