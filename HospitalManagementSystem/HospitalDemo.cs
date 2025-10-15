using System;
using HospitalManagementSystem;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            // Додавання лікарів
            var d1 = new Doctor(1, "Іваненко Олексій", "Терапевт");
            var d2 = new Doctor(2, "Петренко Марія", "Хірург");
            var d3 = new Doctor(3, "Сидоренко Олена", "Педіатр");

            hospital.AddDoctor(d1);
            hospital.AddDoctor(d2);
            hospital.AddDoctor(d3);

            // Реєстрація пацієнтів
            var p1 = new Patient(1, "Коваленко Тарас", 45);
            var p2 = new Patient(2, "Шевченко Ольга", 30);
            var p3 = new Patient(3, "Бондаренко Андрій", 12);
            var p4 = new Patient(4, "Мельник Наталія", 67);

            hospital.RegisterPatient(p1);
            hospital.RegisterPatient(p2);
            hospital.RegisterPatient(p3);
            hospital.RegisterPatient(p4);

            // Створення палат
            var room101 = new HospitalRoom(101, 2);
            var room102 = new HospitalRoom(102, 1);
            var room201 = new HospitalRoom(201, 2);

            hospital.CreateRoom(room101);
            hospital.CreateRoom(room102);
            hospital.CreateRoom(room201);

            // Госпіталізація
            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 101); // має вивести повідомлення про переповнення
            hospital.HospitalizePatient(3, 102);

            // Медичні записи
            var rec1 = new MedicalRecord(p1, d1, DateTime.Now.AddDays(-2), "Гостре респіраторне захворювання. Призначено лікування.");
            var rec2 = new MedicalRecord(p2, d2, DateTime.Now.AddDays(-1), "Післяопераційний огляд. Стан стабільний.");
            var rec3 = new MedicalRecord(p3, d3, DateTime.Now, "Огляд педіатра. Профілактичні щеплення.");

            hospital.AddMedicalRecord(rec1);
            hospital.AddMedicalRecord(rec2);
            hospital.AddMedicalRecord(rec3);

            // Історія пацієнта
            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            // Статистика
            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
