//Iterator Pattern, bir koleksiyonun elemanlarına, koleksiyonun iç yapısını açığa çıkarmadan sırayla erişmeyi sağlayan tasarım desenidir.


namespace Iterator
{
    public class Book
    {
        public string Name { get; }
        public string Author { get; }

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
        }
    }

    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
        void AddItem(T item);
        void RemoveItem(T item);
        T GetItem(int index);
        int Count();
    }

    public class BookListAggregate : IAggregate<Book>
    {
        private List<Book> books = new();

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(this);
        }

        public void AddItem(Book book)
        {
            books.Add(book);
        }

        public void RemoveItem(Book book)
        {
            books.Remove(book);
        }
        public Book GetItem(int index)
        {
            return books[index];
        }

        public int Count()
        {
            return books.Count;
        }
    }

    public class BookIterator : IIterator<Book>
    {
        private IAggregate<Book> aggregate;
        private int currentIndex;

        public BookIterator(IAggregate<Book> aggregate)
        {
            this.aggregate = aggregate;
        }

        public Book Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();

            return aggregate.GetItem(currentIndex++);
        }

        public bool HasNext()
        {
            return currentIndex < aggregate.Count();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Book book1 = new Book("Book1", "Author1");
        Book book2 = new Book("Book2", "Author2");
        Book book3 = new Book("Book3", "Author3");

        BookListAggregate bookListAggregate = new BookListAggregate();
        bookListAggregate.AddItem(book1);
        bookListAggregate.AddItem(book2);
        bookListAggregate.AddItem(book3);
        var iterator = bookListAggregate.CreateIterator();

        while (iterator.HasNext())
        {
            var book = iterator.Next();
            Console.WriteLine($"Name: {book.Name}, Author: {book.Author}");
        }

        Console.ReadKey();
    }
}
