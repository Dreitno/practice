using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice12
{
    class Program
    {
        static void Main()
        {
            // Задание 1 - Работа с коллекциями
            Console.WriteLine("=== Задание 1 ===");
            ArrayList arrayList = new ArrayList() { 1.5, 2.3, 3.7, 4.1 };
            Console.WriteLine("ArrayList:");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            Queue queue = new Queue();
            queue.Enqueue(5.5);
            queue.Enqueue(6.6);
            Console.WriteLine("\nQueue:");
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());

            Hashtable hashtable = new Hashtable();
            hashtable.Add("key1", 7.7);
            hashtable.Add("key2", 8.8);
            Console.WriteLine("\nHashtable:");
            foreach (DictionaryEntry item in hashtable)
                Console.WriteLine($"{item.Key}: {item.Value}");

            // Задание 2 - Обработка исключений
            Console.WriteLine("\n=== Задание 2 ===");
            try
            {
                Console.WriteLine(arrayList[10]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Поймано исключение: выход за границы массива");
            }

            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Поймано исключение: очередь пуста");
            }

            try
            {
                hashtable.Add("key1", 9.9);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Поймано исключение: дублирование ключа");
            }

            // Задание 3 - Обработка коллекции
            Console.WriteLine("\n=== Задание 3 ===");
            ProcessCollection(ref arrayList);
            Console.WriteLine("Обработанный ArrayList:");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            // Задание 4 - Проверка скобок
            Console.WriteLine("\n=== Задание 4 ===");
            string[] brackets = { "()", "(()", ")(", "(()())" };
            foreach (var b in brackets)
                Console.WriteLine($"{b}: {(CheckBrackets(b) ? "правильно" : "неправильно")}");

            // Задание 5 - Работа со студентами
            Console.WriteLine("\n=== Задание 5 ===");
            FindWorstStudent();

            // Задание 6 - Иерархия классов
            Console.WriteLine("\n=== Задание 6 ===");
            TestCollections();
        }

        static void ProcessCollection(ref ArrayList list)
        {
            double sum = 0;
            foreach (double item in list)
                sum += item;
            double avg = sum / list.Count;

            for (int i = 0; i < list.Count; i++)
                if ((double)list[i] < avg)
                    list[i] = 0.0;
        }

        static bool CheckBrackets(string input)
        {
            Stack stack = new Stack();
            foreach (char c in input)
            {
                if (c == '(')
                    stack.Push(c);
                else if (c == ')')
                {
                    if (stack.Count == 0) return false;
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }

        class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int Course { get; set; }
            public int[] Grades { get; set; }

            public double AverageGrade
            {
                get
                {
                    double sum = 0;
                    foreach (int grade in Grades)
                        sum += grade;
                    return sum / Grades.Length;
                }
            }
        }

        static void FindWorstStudent()
        {
            Student[] students = {
                new Student { LastName = "Иванов", FirstName = "Иван", Course = 2, Grades = new[] {3, 3, 3} },
                new Student { LastName = "Петров", FirstName = "Петр", Course = 2, Grades = new[] {4, 4, 4} },
                new Student { LastName = "Сидоров", FirstName = "Сидор", Course = 3, Grades = new[] {5, 5, 5} }
            };

            Student worst = null;
            foreach (var s in students)
                if (s.Course == 2 && (worst == null || s.AverageGrade < worst.AverageGrade))
                    worst = s;

            if (worst != null)
                Console.WriteLine($"Худший студент: {worst.LastName} {worst.FirstName}, средний балл: {worst.AverageGrade}");
        }

        class Person
        {
            public string Name { get; set; }
        }

        class Employee : Person
        {
            public string Position { get; set; }
            public Person GetBasePerson() => this;
        }

        static void TestCollections()
        {
            Dictionary<int, Employee> dict1 = new Dictionary<int, Employee>();
            Dictionary<string, Employee> dict2 = new Dictionary<string, Employee>();

            for (int i = 1; i <= 3; i++)
            {
                var emp = new Employee { Name = $"Сотрудник {i}", Position = "Должность" };
                dict1.Add(i, emp);
                dict2.Add(i.ToString(), emp);
            }

            Console.WriteLine("Тест коллекций:");
            Console.WriteLine($"Найден сотрудник 2: {dict1.ContainsKey(2)}");
            Console.WriteLine($"Найден сотрудник '2': {dict2.ContainsKey("2")}");
        }
    }
}