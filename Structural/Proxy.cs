/*
Proxy Pattern, bir nesneye erişimi kontrol etmek için onun yerine
geçen temsilci bir nesne sunar. Bu temsilci, gerçek nesnenin davranışını
ister geciktirir, ister sınırlar, ister ek işlemler uygular.
*/

namespace Proxy
{

    public class Video
    {
        public string name;
        public string description;
        public byte[] data;

        public Video(string name, string description, byte[] data)
        {
            this.name = name;
            this.description = description;
            this.data = data;
        }

        public void Play()
        {
            //Play the video
        }
    }



    public interface IVideoService
    {
        Video GetVideo(string url);
    }

    public class VideoServiceA : IVideoService
    {
        public Video GetVideo(string url)
        {
            //GetVideo with url 
            return new Video("ProxyPattern", "We would learn proxy pattern", new byte[1000]);
        }
    }


    public class VideoServiceAProxy : IVideoService
    {
        private Dictionary<string, Video> videoDic = new();
        private IVideoService videoService;
        private User user;

        public VideoServiceAProxy(User user)
        {
            this.user = user;
        }

        public Video GetVideo(string url)
        {
            if (user.Age < 18)
                throw new UnauthorizedAccessException("User age must be 18 or bigger");

            if (videoDic.TryGetValue(url, out Video? cachedVideo))
                return cachedVideo;

            if (videoService == null)
                videoService = new VideoServiceA();

            var video = videoService.GetVideo(url);
            videoDic.Add(url, video);

            return video;
        }

    }

    public class User
    {
        private string name;
        private int age;

        public string Name => name;
        public int Age => age;


        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}


public class Program
{
    public static void Main()
    {
        User user1 = new User("Alex", 16);

        VideoServiceAProxy proxyService = new VideoServiceAProxy(user1);
        var video = proxyService.GetVideo("someURL");

        video.Play();


        Console.ReadKey();
    }
}
