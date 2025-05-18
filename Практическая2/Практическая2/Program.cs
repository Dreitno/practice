using System;

namespace UniversityHospital
{

    class Student
    {

        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string RecordBookNumber { get; }


        public int Course { get; set; }
        public string Group { get; set; }
        public string Phone { get; set; }


        public Student(string lastName, string firstName, string middleName, string recordBookNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            RecordBookNumber = recordBookNumber;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Студент: {LastName} {FirstName} {MiddleName}");
            Console.WriteLine($"Номер зачётки: {RecordBookNumber}");
            Console.WriteLine($"Курс: {Course}, Группа: {Group}");
            Console.WriteLine($"Телефон: {Phone}\n");
        }


        public bool SameLastName(Student other)
        {
            return this.LastName == other.LastName;
        }
    }


    class Patient
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int MedicalCardNumber { get; set; }
        public string Diagnosis { get; set; }


        public void PrintInfo()
        {
            Console.WriteLine($"{LastName} {FirstName} {MiddleName}");
            Console.WriteLine($"Мед. карта: {MedicalCardNumber}, Диагноз: {Diagnosis}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("=== Студенты ===");


            Student student1 = new Student("Иванов", "Иван", "Иванович", "ST-001");
            student1.Course = 2;
            student1.Group = "ИП-21";
            student1.Phone = "+99999999";

            Student student2 = new Student("Иванов", "Мария", "Сергеевна", "ST-002");
            student2.Course = 1;
            student2.Group = "ИП-22";
            student2.Phone = "+7777777777777";
            
            student1.PrintInfo();

            student2.PrintInfo();
           
            Console.WriteLine($"У студентов одинаковая фамилия? {student1.SameLastName(student2)}\n");
           
            Console.WriteLine("=== Пациенты ===");

            
            Patient[] patients = new Patient[3];

            patients[0] = new Patient();
            patients[0].LastName = "Сидоров";
            patients[0].FirstName = "Алексей";
            patients[0].MiddleName = "Николаевич";
            patients[0].MedicalCardNumber = 1;
            patients[0].Diagnosis = "Грипп";

            patients[1] = new Patient();
            patients[1].LastName = "Козлова";
            patients[1].FirstName = "Елена";
            patients[1].MiddleName = "Владимировна";
            patients[1].MedicalCardNumber = 2;
            patients[1].Diagnosis = "Ангина";

            patients[2] = new Patient();
            patients[2].LastName = "Фёдоров";
            patients[2].FirstName = "Михаил";
            patients[2].MiddleName = "Сергеевич";
            patients[2].MedicalCardNumber = 3;
            patients[2].Diagnosis = "Грипп";

            // Выводим всех пациентов
            Console.WriteLine("Все пациенты:");
            foreach (Patient p in patients)
            {
                p.PrintInfo();
            }


            Console.WriteLine("Пациенты с диагнозом 'Грипп':");
            foreach (Patient p in patients)
            {
                if (p.Diagnosis.ToLower() == "грипп")
                {
                    p.PrintInfo();
                }
            }

            // Поиск пациентов с номерами карт от 1002 до 1003
            Console.WriteLine("Пациенты с номерами карт от 1002 до 1003:");
            foreach (Patient p in patients)
            {
                if (p.MedicalCardNumber >= 2 && p.MedicalCardNumber <= 3)
                {
                    p.PrintInfo();
                }
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}