using System;

namespace attr
{
    class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person("Tom", 35);
            Person bob = new Person("Bob", 16);
            ValidateUser(tom);    // true
            ValidateUser(bob);    // false

            //Console.WriteLine($"Результат валидации Тома: {tomIsValid}");
           // Console.WriteLine($"Результат валидации Боба: {bobIsValid}");

            void ValidateUser(Person person)
            {
                Type type = typeof(Person);
                // получаем все атрибуты класса Person
                object[] attributes = type.GetCustomAttributes(false);

                // проходим по всем атрибутам
                foreach (Attribute attr in attributes)
                {
                    // если атрибут представляет тип AgeValidationAttribute
                    if (attr is AgeValidationAttribute ageAttribute)
                        // возвращаем результат проверки по возрасту
                        Console.WriteLine(person.Age >= ageAttribute.Age);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }

    [AgeValidation(18)]
    [AgeValidation(15)]
    public class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
