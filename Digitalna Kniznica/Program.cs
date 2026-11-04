namespace Digitalna_Kniznica;

public class Author
{
    string _Name;
    List<Book> _Books = new List<Book>();

    public Author(string n)
    {
        _Name = n;
    }
    
    public Book WriteBook(string bookName, int publicationYear)
    {
        Book b = new Book(bookName, this, publicationYear);
        _Books.Add(b);
        return b;
    }

    List<Author> Authors = new List<Author>();
    public Author AddAuthor()
    
    public string Name()
    {
        return _Name;
    }

    public List<Book> Books()
    {
        return _Books;
    }
    
    public void Display()
    {
        Console.WriteLine("Author: " + Name() + " Books # written: " + Books().Count);
    }
}

public class Book
{
    string _Name;
    Author _Author;
    int PublicationYear;
    private bool Borrowed; // malo by to byt v inej triede

    public Book(string n, Author a, int y)
    {
        _Name = n;
        _Author = a;
        PublicationYear = y;
    }

    public string Name()
    {
        return _Name;
    }
    public Author Author()
    {
        return _Author;
    }

    public void Display()
    {
        Console.WriteLine("Book: " + Name() + " Written by: " + Author().Name() + " Published in: " + PublicationYear + " Borrowed: " + Borrowed);
    }
}


class Library
{
    HashSet<Book> Books = new HashSet<Book>();

    public bool BuyBook(Book b)
    {
        return Books.Add(b);
    }

    public Author FindAuthor(string name) // predpokladame ze mena su unikatne
    {
        foreach (var b in Books)
        {
            if (b.Author().Name().Equals(name))
            {
                return b.Author();
            }
        }
        return null;
    }


    static void Main(string[] args)
    {
        // autori
        Author tolk = new Author("JrrTolkien");
        Author sExupery = new Author("Saint-Exupery");
        Author jAusten = new Author("Jane Austen");
        // knihy autorov
        Book hob = tolk.WriteBook("Hobbit", 1937);
        Book lotr = tolk.WriteBook("Lord of the Rings", 1954);
        Book lilprince = sExupery.WriteBook("Little Prince", 1943);
        Book pride = jAusten.WriteBook("Pride and Prejudice", 1813);
        // nakup knih
        Library lib = new Library();
        lib.BuyBook(hob);
        lib.BuyBook(lotr);
        lib.BuyBook(lilprince);
        lib.BuyBook(pride);

        Console.WriteLine("Name a book's name, the author, and the year of publication: ");
        string bn = Console.ReadLine();
        int bpy = int.Parse(Console.ReadLine());
        
        // hladanie autora
        Author aFound = lib.FindAuthor("JrrTolkien");
        aFound.Display();
        foreach (var b in aFound.Books())
        {
            b.Display();
        }

        aFound = lib.FindAuthor("Sveto");
        Console.WriteLine("Find Sveto: >" + aFound + "<");
    }
}