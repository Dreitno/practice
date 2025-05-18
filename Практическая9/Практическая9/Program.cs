using System;

namespace Practice9
{
    // Задание 1
    abstract class BaseArray
    {
        protected int[] array;

        public BaseArray(int size)
        {
            array = new int[size];
        }

        public int Size => array.Length;

        public abstract void Process();

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
    }

    class DerivedArray : BaseArray
    {
        public DerivedArray(int size) : base(size) { }

        public override void Process()
        {
            Console.WriteLine("Элементы массива:");
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }

    // Задание 2
    abstract class TwoFieldsBase
    {
        protected int field1;
        protected int field2;

        public TwoFieldsBase(int a, int b)
        {
            field1 = a;
            field2 = b;
        }

        public abstract int this[int index] { get; set; }
    }

    interface ICalculator
    {
        int Calculate(int multiplier);
    }

    class FieldsCalculator : TwoFieldsBase, ICalculator
    {
        public FieldsCalculator(int a, int b) : base(a, b) { }

        public override int this[int index]
        {
            get => index % 2 == 0 ? field1 : field2;
            set
            {
                if (index % 2 == 0)
                    field1 = value;
                else
                    field2 = value;
            }
        }

        public int Calculate(int multiplier)
        {
            return (field1 + field2) * multiplier;
        }
    }

    // Задание 3
    abstract class AbstractBase
    {
        public abstract int Value { get; set; }
        public abstract int this[int index] { get; set; }
        public abstract void Operation();
    }

    interface IFirstInterface
    {
        int Value { get; set; }
        int this[int index] { get; set; }
        void Operation();
    }

    interface ISecondInterface
    {
        int Value { get; set; }
        int this[int index] { get; set; }
        void Operation();
    }

    class CombinedClass : AbstractBase, IFirstInterface, ISecondInterface
    {
        private int[] data = new int[10];
        private int value;

        int IFirstInterface.Value
        {
            get => value + 1;
            set => this.value = value - 1;
        }

        int ISecondInterface.Value
        {
            get => value + 2;
            set => this.value = value - 2;
        }

        public override int Value
        {
            get => value;
            set => this.value = value;
        }

        int IFirstInterface.this[int index]
        {
            get => data[index] * 2;
            set => data[index] = value / 2;
        }

        int ISecondInterface.this[int index]
        {
            get => data[index] * 3;
            set => data[index] = value / 3;
        }

        public override int this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        void IFirstInterface.Operation() => Console.WriteLine("Операция 1");
        void ISecondInterface.Operation() => Console.WriteLine("Операция 2");
        public override void Operation() => Console.WriteLine("Базовая операция");
    }

    class Program
    {
        static void Main()
        {
            // Задание 1
            DerivedArray arr = new DerivedArray(5);
            for (int i = 0; i < arr.Size; i++)
                arr[i] = i * 2;
            arr.Process();

            // Задание 2
            FieldsCalculator calc = new FieldsCalculator(10, 20);
            Console.WriteLine($"Поле 1: {calc[0]}, Поле 2: {calc[1]}");
            Console.WriteLine($"Результат: {calc.Calculate(3)}");

            // Задание 3
            CombinedClass obj = new CombinedClass();
            obj.Value = 10;
            obj[0] = 100;

            IFirstInterface first = obj;
            ISecondInterface second = obj;

            first.Value = 10;
            second.Value = 20;
            first[1] = 60;
            second[2] = 90;

            Console.WriteLine($"Значения: {obj.Value}, {first.Value}, {second.Value}");
            Console.WriteLine($"Элементы: {obj[0]}, {first[1]}, {second[2]}");

            obj.Operation();
            first.Operation();
            second.Operation();
        }
    }
}