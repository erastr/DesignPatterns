/*
Singleton Pattern, bir sınıfın uygulama boyunca yalnızca tek bir örneğinin
oluşmasını ve bu örneğe global erişim sağlanmasını garanti eder.
Paylaşılan durum yönetimi gerektiren yapılarda kullanılır.
*/

namespace Singleton
{
    public sealed class GameSettings //Sealed class olması kalıtım olmaması için kullanılması daha iyidir.
    {
        private static GameSettings instance;
        private static object lockObject = new();

        private GameSettings()
        {
            //Must be private for blocking -new()
        }

        public static GameSettings GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new GameSettings();
                    }
                }
            }


            return instance;
        }
    }
}



class Program
{
    public static void Main()
    {


        var settings = GameSettings.GetInstance();
        var settings2 = GameSettings.GetInstance();

        if (settings2 == settings)
        {
            Console.WriteLine("Instances are same");
            //They must be always true
        }


        Console.ReadKey();
    }
}
