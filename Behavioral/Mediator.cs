// Mediator Pattern, nesnelerin birbirleriyle doğrudan iletişim kurmasını engelleyip, tüm iletişimi merkezi bir aracı (mediator) üzerinden yönetmeyi sağlayan tasarım desenidir.Bu sayede nesneler arasındaki bağımlılık (coupling) azaltılır ve sistem daha esnek hale gelir. Mediator, mesajları ilgili nesnelere yönlendirir (broadcast veya private), böylece iletişim kontrolü tek noktada toplanır.



namespace Mediator
{

    class User
    {
        public int Id { get; }
        public string Name { get; }

        private IChatRoomMediator chatRoomMediator;

        public User(int id, string name, IChatRoomMediator chatRoomMediator)
        {
            Id = id;
            Name = name;
            this.chatRoomMediator = chatRoomMediator;
        }

        public void ReceiveMessage(User sender, string message)
        {
            Console.WriteLine($"ReceivedMessage: {message} sender Name: {sender.Name}");
        }

        public void SendMessage(string message)
        {
            chatRoomMediator.SendMessage(this, message);
        }
    }

    interface IChatRoomMediator
    {
        void SendMessage(User user, string message);
        void AddUser(User user);

    }

    class ChatRoomMediator : IChatRoomMediator
    {
        private Dictionary<int, User> users = new();
        public void AddUser(User user)
        {
            if (users.ContainsKey(user.Id))
            {
                Console.WriteLine("User Already In Room");
                return;
            }

            users[user.Id] = user;
        }

        public void SendMessage(User sender, string message)
        {
            foreach (var user in users.Values)
            {
                if (user.Id == sender.Id)
                    continue;

                user.ReceiveMessage(sender, message);
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        ChatRoomMediator chatRoomMediator = new ChatRoomMediator();

        User user1 = new User(1, "User1", chatRoomMediator);
        User user2 = new User(2, "User2", chatRoomMediator);
        User user3 = new User(3, "User3", chatRoomMediator);
        User user4 = new User(4, "User4", chatRoomMediator);

        chatRoomMediator.AddUser(user1);
        chatRoomMediator.AddUser(user2);
        chatRoomMediator.AddUser(user3);
        chatRoomMediator.AddUser(user4);

        user1.SendMessage("Nasılsınız?");
        user2.SendMessage("İyidir Sen?");

        Console.ReadKey();
    }
}
