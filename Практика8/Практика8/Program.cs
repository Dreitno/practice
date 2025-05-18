using System;
using System.Collections.Generic;

namespace Practice8
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name) => Name = name;

        public virtual void MakeSound() => Console.WriteLine("Животное издает звук");
    }

    class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound() => Console.WriteLine($"{Name} гав");

        public void Fetch() => Console.WriteLine($"{Name} приносит палку");
    }

    class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound() => Console.WriteLine($"{Name} мяу!");

        public void ClimbTree() => Console.WriteLine($"{Name} залезает на дерево");
    }

    class Program
    {
        static Dog GetDog() => new Dog("собака");
        static Cat GetCat() => new Cat("кошка");
        static Animal GetAnimal() => new Animal("Зверь");

        static void ProcessAnimal(Animal animal)
        {
            Console.WriteLine($"Обрабатываем: {animal.Name}");
            animal.MakeSound();
        }

        static void ProcessDog(Dog dog)
        {
            Console.WriteLine($"Обрабатываем собаку: {dog.Name}");
            dog.Fetch();
        }

        static void Main()
        {
            Func<Dog> getDog = GetDog;
            Func<Animal> getAnimal = getDog;
            getAnimal().MakeSound();

            Action<Animal> animalAction = ProcessAnimal;
            Action<Dog> dogAction = animalAction;
            dogAction(new Dog("собака2"));

            var zoo = new List<Animal> { new Dog("собака3"), new Cat("кошка2") };

            Func<Animal, Animal> processor = a =>
            {
                a.MakeSound();
                return a;
            };

            foreach (var animal in zoo)
            {
                if (animal is Dog d)
                    processor(d);
                else
                    processor(animal);
            }
        }
    }
}