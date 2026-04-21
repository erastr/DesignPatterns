//Command Pattern, bir isteği (işlemi) nesne haline getirerek çağıran (invoker) ile işi yapan (receiver) arasındaki bağı gevşeten bir tasarım desenidir. Bu sayede işlemler parametre olarak taşınabilir, sıraya alınabilir, loglanabilir ve geri alınabilir (undo). Özellikle input sistemleri, UI butonları ve işlem geçmişi yönetimi gibi senaryolarda kullanılır



namespace Command
{

    public interface ICommand
    {
        void Execute();
        void Undo();
    }


    public class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.Open();
        }
        public void Undo()
        {
            light.Close();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.Close();
        }
        public void Undo()
        {
            light.Open();
        }
    }

    public class TVOpenCommand : ICommand
    {
        private TV tv;

        public TVOpenCommand(TV tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.Open();
        }
        public void Undo()
        {
            tv.Close();
        }
    }

    public class TVCloseCommand : ICommand
    {
        private TV tv;

        public TVCloseCommand(TV tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.Close();
        }
        public void Undo()
        {
            tv.Open();
        }
    }

    public class TV
    {
        public void Open()
        {
            Console.WriteLine("TV Open");
        }

        public void Close()
        {
            Console.WriteLine("TV Closed");
        }
    }

    public class Light
    {
        public void Open()
        {
            Console.WriteLine("Light On");
        }

        public void Close()
        {
            Console.WriteLine("Light Off");
        }
    }


    public class CommandInvoker
    {
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (commandHistory.Count == 0)
                return;

            var lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Light light = new Light();
        var lightOpenCommand = new LightOnCommand(light);
        var lightCloseCommand = new LightOffCommand(light);
        TV tv = new TV();
        var tvOpenCommand = new TVOpenCommand(tv);
        var tvCloseCommand = new TVCloseCommand(tv);

        var invoker = new CommandInvoker();

        invoker.ExecuteCommand(lightOpenCommand);
        invoker.ExecuteCommand(lightCloseCommand);
        invoker.ExecuteCommand(tvOpenCommand);
        invoker.ExecuteCommand(tvCloseCommand);

        invoker.UndoLastCommand();

        Console.ReadKey();

    }
}
