using System;

class Person
{
    // Приватні поля
    private string name;
    private DateTime birthYear;

    // Властивості
    public string Name => name;
    public DateTime BirthYear => birthYear;

    // Конструктор
    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.MinValue;
    }

    // Конструктор з параметрами
    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    // Метод для обчислення віку особи
    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    // Метод для введення даних про особу
    public void Input()
    {
        Console.Write("Введіть ім'я: ");
        name = Console.ReadLine();

        Console.Write("Введіть рік народження: ");
        int year = int.Parse(Console.ReadLine());
        birthYear = new DateTime(year, 1, 1);
    }

    // Метод для зміни імені особи
    public void ChangeName(string newName)
    {
        name = newName;
    }

    // Перевизначення методу ToString()
    public override string ToString()
    {
        return $"Ім'я: {name}, Рік народження: {birthYear.Year}, Вік: {Age()}";
    }

    // Метод для виведення інформації 
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person p1, Person p2)
    {
        return p1.name == p2.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return name == other.name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        // Створення масиву для зберігання шести об'єктів Person
        Person[] people = new Person[6];

        // Введення інформації про 6 осіб
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"Введіть дані для особи {i + 1}:");
            people[i] = new Person();
            people[i].Input();
        }

        // Виведення імен та віку кожної особи
        Console.WriteLine("\nІмена та вік кожної особи:");
        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Name}: {person.Age()} років");
        }

        // Зміна імені осіб, чий вік менший за 16 років
        Console.WriteLine("\nЗміна імені осіб, чий вік менший за 16 років:");
        foreach (Person person in people)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        // Виведення інформації про всіх осіб
        Console.WriteLine("\nІнформація про всіх осіб після змін:");
        foreach (Person person in people)
        {
            person.Output();
        }

        // Пошук та виведення інформації про осіб з однаковими іменами
        Console.WriteLine("\nОсоби з однаковими іменами:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"{people[i].ToString()} та {people[j].ToString()} мають однакове ім'я.");
                }
            }
        }
    }
}