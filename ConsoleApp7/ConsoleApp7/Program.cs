using System;
using System.Collections;
using System.Collections.Generic;

// Класс Book
public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({Year})";
    }
}

// Класс Library
public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in books)
        {
            yield return book;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("Война И Мир", "Лев толстой", 1869));
        library.AddBook(new Book("Гордость и предубеждение", "Джейн Остен", 1813));
        library.AddBook(new Book("Убить пересмешника", "Харпер Ли", 1960));

        Console.WriteLine("Books in the library:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}
