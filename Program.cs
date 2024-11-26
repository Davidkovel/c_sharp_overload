using System;

public class Store
{
    public string Name { get; set; }
    public int YearOfEstablishment { get; set; }
    public string Description { get; set; }
    public string ContactPhone { get; set; }
    public string Email { get; set; }
    public double Area { get; set; }

    public Store()
    {
        this.Name = "";
        this.YearOfEstablishment = 0;
        this.Description = "";
        this.ContactPhone = "";
        this.Email = "";
        this.Area = 0;
    }

    public Store(string name, int year, string description, string phone, string email, double area) : this()
    {
        this.Name = name;
        this.YearOfEstablishment = year;
        this.Description = description;
        this.ContactPhone = phone;
        this.Email = email;
        this.Area = area;
    }

    public void InputData()
    {
        Console.Write("Enter the store name: ");
        Name = Console.ReadLine();

        Console.Write("Enter the year of establishment: ");
        YearOfEstablishment = int.Parse(Console.ReadLine());

        Console.Write("Enter the store description: ");
        Description = Console.ReadLine();

        Console.Write("Enter the contact phone number: ");
        ContactPhone = Console.ReadLine();

        Console.Write("Enter the email: ");
        Email = Console.ReadLine();

        Console.Write("Enter the area of the store (in square meters): ");
        Area = Convert.ToDouble(Console.ReadLine());
    }

    public void OutputData()
    {
        Console.WriteLine($"Store Name: {Name}");
        Console.WriteLine($"Year of Establishment: {YearOfEstablishment}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Contact Phone: {ContactPhone}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Area: {Area} square meters");
    }

    public static Store operator +(Store store, double areaIncrease)
    {
        store.Area += areaIncrease;
        return store;
    }

    public static Store operator -(Store store, double areaDecrease)
    {
        if (store.Area - areaDecrease < 0)
        {
            Console.WriteLine("Error: The area cannot be less than 0");
        }
        else
        {
            store.Area -= areaDecrease;
        }
        return store;
    }

    public static bool operator ==(Store store1, Store store2)
    {
        return store1.Area == store2.Area;
    }

    public static bool operator !=(Store store1, Store store2)
    {
        return store1.Area != store2.Area;
    }

    public static bool operator >(Store store1, Store store2)
    {
        return store1.Area > store2.Area;
    }

    public static bool operator <(Store store1, Store store2)
    {
        return store1.Area < store2.Area;
    }

    public override string ToString()
    {
        return $"Store Name: {Name}, Year: {YearOfEstablishment}, Description: {Description}, Phone: {ContactPhone}, Email: {Email} Area: {Area} square meters";
    }

    public override bool Equals(object obj)
    {
        if (obj is Store otherStore)
        {
            return this.Name == otherStore.Name &&
                   this.YearOfEstablishment == otherStore.YearOfEstablishment &&
                   this.Description == otherStore.Description &&
                   this.ContactPhone == otherStore.ContactPhone &&
                   this.Email == otherStore.Email &&
                   this.Area == otherStore.Area;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Store store1 = new Store { Name = "Shop steam", YearOfEstablishment = 2020, Area = 150.5 };
        Store store2 = new Store { Name = "Shop epic games", YearOfEstablishment = 2021, Area = 200.0 };

        store1 += 100;
        store2 -= 80;

        store1.OutputData();
        Console.WriteLine();
        store2.OutputData();

        Console.WriteLine();
        Console.WriteLine($"Is area equal: {store1 == store2}");
        Console.WriteLine($"Is area store 1 larger than store 2: {store1 > store2}");


    }
}

/*
Store Name: Shop steam
Year of Establishment: 2020
Description:
Contact Phone:
Email:
Area: 250,5 square meters

Store Name: Shop epic games
Year of Establishment: 2021
Description:
Contact Phone:
Email:
Area: 120 square meters

Is area equal: False
Is area store 1 larger than store 2: True

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (процесс 18496) завершил работу с кодом 0 (0x0).
Нажмите любую клавишу, чтобы закрыть это окно…
*/