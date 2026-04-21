/*
    Observer Pattern: Bir nesnenin (Subject) durum değişikliğini,
    ona abone olan nesnelere (Observer) otomatik olarak bildiren tasarım desenidir.
    Gevşek bağlı (loosely coupled) sistemler kurmak için kullanılır.
*/

namespace Observer
{

    public class News
    {
        public string Subject { get; }
        public string Details { get; }
        public News(string subject, string details)
        {
            Subject = subject;
            Details = details;
        }
    }

    interface IObserver<T>
    {
        void Update(T news);
    }

    interface ISubject<T>
    {
        void AddObserver(IObserver<T> observer);
        void RemoveObserver(IObserver<T> observer);
    }

    class User : IObserver<News>
    {
        public string Name { get; }
        public string Email { get; }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void Update(News news)
        {
            Console.WriteLine($"{Name} received news: {news.Subject} - {news.Details}");
        }
    }

    class NewsAgency : ISubject<News>
    {
        private readonly List<IObserver<News>> observers = new();

        public void AddObserver(IObserver<News> observer)
        {
            if (observers.Contains(observer))
            {
                Console.WriteLine("Observer already registered");
                return;
            }

            observers.Add(observer);
        }

        public void RemoveObserver(IObserver<News> observer)
        {
            if (!observers.Contains(observer))
            {
                Console.WriteLine("Observer not found");
                return;
            }

            observers.Remove(observer);
        }

        public void PublishNews(News news)
        {
            Notify(news);
        }

        private void Notify(News news)
        {
            foreach (var item in observers.ToList())
                item.Update(news);
        }

    }
}

class Program
{
    public static void Main()
    {
        User jason = new User("Jason", "jason@jason.com");
        User kate = new User("Kate", "kate@kate.com");

        NewsAgency newsAgency = new NewsAgency();

        News news1 = new News("SubjectName1", "SubjectDetails1");
        News news2 = new News("SubjectName2", "SubjectDetails2");

        newsAgency.AddObserver(jason);
        newsAgency.AddObserver(kate);

        newsAgency.PublishNews(news1);
        newsAgency.RemoveObserver(kate);
        newsAgency.PublishNews(news2);

        Console.ReadKey();
    }
}
