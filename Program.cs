using System;

class Journal
{
    public string Name { get; set; }
    public int YearOfEstablishment { get; set; }
    public string Description { get; set; }
    public string ContactPhone { get; set; }
    public string Email { get; set; }
    public int Employee {  get; set; }

    public Journal() {
        this.Name = "";
        this.YearOfEstablishment = 0;
        this.Description = "";
        this.ContactPhone = "";
        this.Email = "";
        this.Employee = 0;
    }
    public Journal(string name, int year, string description, string phone, string email, int employee_count) : this()
    {
        this.Name = name;
        this.YearOfEstablishment = year;
        this.Description = description;
        this.ContactPhone = phone;
        this.Email = email;
        this.Employee = employee_count;
    }
    public void InputData()
    {
        Console.Write("Enter the journal name: ");
        Name = Console.ReadLine();

        Console.Write("Enter the year of establishment: ");
        YearOfEstablishment = int.Parse(Console.ReadLine());

        Console.Write("Enter the journal description: ");
        Description = Console.ReadLine();

        Console.Write("Enter the contact phone number: ");
        ContactPhone = Console.ReadLine();

        Console.Write("Enter the email: ");
        Email = Console.ReadLine();

        Console.Write("Enter the count of employee: ");
        Employee = Convert.ToInt32(Console.ReadLine());
    }

    public void OutputData()
    {
        Console.WriteLine($"Journal Name: {Name}");
        Console.WriteLine($"Year of Establishment: {YearOfEstablishment}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Contact Phone: {ContactPhone}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Employee: {Employee}");
    }

    public static Journal operator +(Journal journal, int count)
    {
        journal.Employee += count;
        return journal;
    }

    public static Journal operator -(Journal journal, int count)
    {
        if (journal.Employee - count < 0)
        {
            Console.WriteLine("Помилка: кількість співробітників не може бути меншою за 0");
        }
        else
        {
            journal.Employee -= count;
        }
        return journal;
    }


    public static bool operator ==(Journal journal1, Journal journal2)
    {
        return journal1.Name == journal2.Name;
    }



    public static bool operator !=(Journal journal1, Journal journal2)
    {
        return journal1.Name != journal2.Name;
    }

    public static bool operator >(Journal journal1, Journal journal2)
    {
        return (journal1 > journal2);
    }

    public static bool operator <(Journal journal1, Journal journal2)
    {
        return (journal1 < journal2);
    }

    public override string ToString()
    {
        return $"Journal Name: {Name}, Year: {YearOfEstablishment}, Employees: {Employee} ...";
    }

    public override bool Equals(object obj)
    {
        if (obj is Journal otherJournal)
        {
            return this.Name == otherJournal.Name &&
                   this.YearOfEstablishment == otherJournal.YearOfEstablishment &&
                   this.Employee == otherJournal.Employee &&
                   this.Description == otherJournal.Description &&
                   this.Email == otherJournal.Email &&
                   this.ContactPhone == otherJournal.ContactPhone;

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

        Journal journal = new Journal("Tech Journal", 2024, "A technology journal", "123-456-7890", "tech@example.com", 5);

        journal.OutputData();
        Console.WriteLine();

        journal -= 6;
        Console.WriteLine();
        journal.OutputData();

        journal -= 3;
        Console.WriteLine();
        journal.OutputData();


    }
}

/*
Journal Name: Tech Journal
Year of Establishment: 2024
Description: A technology journal
Contact Phone: 123-456-7890
Email: tech@example.com
Employee: 5

Помилка: кількість співробітників не може бути меншою за 0

Journal Name: Tech Journal
Year of Establishment: 2024
Description: A technology journal
Contact Phone: 123-456-7890
Email: tech@example.com
Employee: 5

Journal Name: Tech Journal
Year of Establishment: 2024
Description: A technology journal
Contact Phone: 123-456-7890
Email: tech@example.com
Employee: 2

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (процесс 22240) завершил работу с кодом 0 (0x0).
Нажмите любую клавишу, чтобы закрыть это окно…
*/