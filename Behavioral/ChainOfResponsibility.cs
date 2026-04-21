//Chain Of Responsibility => CoR
//Aciklama:
//CoR tasarım deseni bir isteği sırasıyla handler'lara yollayarak uygun olan handler'da işler ve işlemi tamamlar. 
//Zincir boyunca isteği handle etmeye çalışır. Doğru Handler'ı bulana kadar devam eder.
//Eğer hiç bir handler durumu işleyemiyorsa UnkownHandler açılır yapı güvenceye alınır.


namespace ChainOfResponsibility
{

    public class Notification
    {
        public NotificationType Type { get; }
        public PriorityType Priority { get; }
        public string Content { get; }

        public Notification(NotificationType type, PriorityType priority, string content)
        {
            Type = type;
            Priority = priority;
            Content = content;
        }
    }

    public enum PriorityType
    {
        Low,
        Medium,
        High
    }

    public enum NotificationType
    {
        Email,
        Sms,
        Push,
        Unknown
    }

    public class ResultNotificationContext
    {
        public Notification Notification { get; }
        public string Message { get; }

        public ResultNotificationContext(Notification notification, string message)
        {
            Notification = notification;
            Message = message;
        }
    }

    public interface IHandler
    {
        IHandler SetNextHandler(IHandler nextHandler);
        ResultNotificationContext Handle(Notification notification);
    }


    public abstract class BaseHandler : IHandler
    {
        protected IHandler nextHandler;

        public IHandler SetNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
            return nextHandler;
        }

        public ResultNotificationContext Handle(Notification notification)
        {
            if (CanHandle(notification))
            {
                var result = Process(notification);
                return result;
            }
            else if (nextHandler != null)
            {
                var result = nextHandler.Handle(notification);
                return result;
            }
            else
            {
                throw new NullReferenceException("Unknown Handle Eklenmemis");
            }
        }

        public abstract bool CanHandle(Notification notification);
        public abstract ResultNotificationContext Process(Notification notification);

    }


    public class EmailHandler : BaseHandler
    {
        public override bool CanHandle(Notification notification)
        {
            return notification.Type == NotificationType.Email;
        }

        public override ResultNotificationContext Process(Notification notification)
        {
            var context = new ResultNotificationContext(notification, "Email Notification handle edildi");
            return context;
        }
    }

    public class SmsHandler : BaseHandler
    {
        public override bool CanHandle(Notification notification)
        {
            return notification.Type == NotificationType.Sms;
        }

        public override ResultNotificationContext Process(Notification notification)
        {
            var context = new ResultNotificationContext(notification, "Sms Notification handle edildi");
            return context;
        }
    }

    public class PushHandler : BaseHandler
    {
        public override bool CanHandle(Notification notification)
        {
            return notification.Type == NotificationType.Push;
        }

        public override ResultNotificationContext Process(Notification notification)
        {
            var context = new ResultNotificationContext(notification, "Push Notification handle edildi");
            return context;
        }
    }
    public class UnknownHandler : BaseHandler
    {
        public override bool CanHandle(Notification notification)
        {
            return true;
        }

        public override ResultNotificationContext Process(Notification notification)
        {
            var context = new ResultNotificationContext(notification, "Notification handle Edilemedi");
            return context;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Notification notification = new Notification(NotificationType.Unknown, PriorityType.Medium, "Yeni Yıl Güncellemesi Geldi");

        EmailHandler emailHandler = new EmailHandler();
        SmsHandler smsHandler = new SmsHandler();
        PushHandler pushHandler = new PushHandler();
        UnknownHandler unknownHandler = new UnknownHandler();

        emailHandler
            .SetNextHandler(smsHandler)
            .SetNextHandler(pushHandler)
            .SetNextHandler(unknownHandler);


        var resultContext = emailHandler.Handle(notification);

        Console.WriteLine(resultContext.Message);



        Console.ReadKey();
    }
}
