// Memento Pattern, bir nesnenin iç durumunu (state) dış dünyaya açmadan saklamayı
// ve gerektiğinde bu duruma geri dönmeyi sağlayan tasarım desenidir.
// Genellikle undo/redo sistemleri, save-load mekanizmaları ve checkpoint yapılarında kullanılır.


namespace Memento
{

    class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class PlayerMemento
    {
        public int Level { get; }
        public int Health { get; }
        public Position Position { get; }
        public PlayerMemento(int level, int health, Position position)
        {
            Level = level;
            Health = health;
            Position = new Position(position.X, position.Y);
        }
    }

    class Player
    {
        private int level;
        private int health;
        private Position position;

        public Player(int level, int health, Position position)
        {
            this.level = level;
            this.health = health;
            this.position = position;
        }

        public void SetState(int level, int health, Position position)
        {
            this.level = level;
            this.health = health;
            this.position = new Position(position.X, position.Y);
        }

        public PlayerMemento Save()
        {
            return new PlayerMemento(level, health, position);
        }

        public void Restore(PlayerMemento playerMemento)
        {
            level = playerMemento.Level;
            health = playerMemento.Health;
            position = new Position(playerMemento.Position.X, playerMemento.Position.Y);
        }
    }

    class PlayerCareTaker
    {
        private Stack<PlayerMemento> history = new();

        public void Save(PlayerMemento playerMemento)
        {
            history.Push(playerMemento);
        }

        public PlayerMemento Undo()
        {
            if (history.Count == 0)
                throw new ArgumentOutOfRangeException("No history to undo");

            return history.Pop();
        }
    }
}


public class Program
{
    public static void Main()
    {
        Player player = new Player(10, 100, new Position(1, 1));
        PlayerCareTaker playerCareTaker = new PlayerCareTaker();

        playerCareTaker.Save(player.Save());
        player.SetState(11, 80, new Position(1, 2));

        var previousMemento = playerCareTaker.Undo();
        player.Restore(previousMemento);

        Console.ReadKey();
    }
}
