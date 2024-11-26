using System;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book() { }
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}

public class ReadingList
{
    private List<Book> books { get; set; } = new List<Book>();

    public ReadingList()
    {
        books = new List<Book>();
    }

    public List<Book> Books
    {
        get { return books; }
    }

    public int Count
    {
        get { return books.Count; }
    }

    public void AddBook(Book book)
    {
        if (!books.Contains(book))
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the reading list.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is already in the list.");
        }
    }

    public void RemoveBook(Book book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
            Console.WriteLine($"Book '{book.Title}' removed from the reading list.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not in the list.");
        }
    }

    public bool ContainsBook(Book book)
    {
        return books.Contains(book);
    }

    public static ReadingList operator +(ReadingList list, Book book)
    {
        list.AddBook(book);
        return list;
    }

    public static ReadingList operator -(ReadingList list, Book book)
    {
        list.RemoveBook(book);
        return list;
    }

    public static bool operator ==(ReadingList list1, ReadingList list2)
    {
        return list1.Count == list2.Count;
    }

    public static bool operator !=(ReadingList list1, ReadingList list2)
    {
        return list1.Count != list2.Count;
    }

    public override bool Equals(object obj)
    {
        if (obj is ReadingList otherList)
        {
            return this.Count == otherList.Count;
        }
        return false;
    }

    public Book this[int index]
    {
        get
        {
            if (index >= 0 && index < books.Count)
            {
                return books[index];
            }
            throw new IndexOutOfRangeException("Invalid index");
        }
        set
        {
            books[index] = value;
        }
    }

    public void PrintBooks()
    {
        Console.WriteLine("Books in your reading list:");
        foreach (var book in books)
        {
            Console.WriteLine(book.ToString());
        }
    }
}

class Program
{
    static void Main()
    {
        ReadingList readingList = new ReadingList();

        Book book1 = new Book("George title", "George Orwell");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");
        Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald");

        readingList += book1;
        readingList += book2;
        readingList += book3;

        Console.WriteLine();
        readingList.PrintBooks();
        Console.WriteLine();

        Console.WriteLine($"Is book already contain: {readingList.ContainsBook(book1)}");

        readingList -= book2;

        Console.WriteLine();
        readingList.PrintBooks();

        try
        {
            Console.WriteLine("Book at index 1: " + readingList[1].ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


/*
Book 'George title' added to the reading list.
Book 'To Kill a Mockingbird' added to the reading list.
Book 'The Great Gatsby' added to the reading list.

Books in your reading list:
George title by George Orwell
To Kill a Mockingbird by Harper Lee
The Great Gatsby by F. Scott Fitzgerald

Is book already contain: True
Book 'To Kill a Mockingbird' removed from the reading list.

Books in your reading list:
George title by George Orwell
The Great Gatsby by F. Scott Fitzgerald
Book at index 1: The Great Gatsby by F. Scott Fitzgerald

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (процесс 17640) завершил работу с кодом 0 (0x0).
Нажмите любую клавишу, чтобы закрыть это окно:

 
 
 */