/*
Builder Pattern, karmaşık nesnelerin oluşturulma sürecini adım adım yöneterek
aynı oluşturma sürecinden farklı temsiller üretmeyi sağlar.
Nesnenin oluşturulma mantığı ile temsilinin ayrılmasını hedefler.
*/
namespace Builder
{
    public class Character
    {
        public int Health { get; }
        public int Mana { get; }
        public int Damage { get; }
        public bool IsAIControlled { get; }

        internal Character(int health, int mana, int damage, bool isAIControlled)
        {
            Health = health;
            Mana = mana;
            Damage = damage;
            IsAIControlled = isAIControlled;
        }

        public void Print()
        {
            Console.WriteLine($"HP:{Health} Mana:{Mana} DMG:{Damage} AI:{IsAIControlled}");
        }
    }


    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHealth(int value);
        ICharacterBuilder SetMana(int value);
        ICharacterBuilder SetDamage(int value);
        ICharacterBuilder SetAI(bool value);
        Character Build();
    }

    public class CharacterBuilder : ICharacterBuilder
    {
        private int health;
        private int mana;
        private int damage;
        private bool isAI;

        public ICharacterBuilder SetHealth(int value)
        {
            health = value;
            return this;
        }

        public ICharacterBuilder SetMana(int value)
        {
            mana = value;
            return this;
        }

        public ICharacterBuilder SetDamage(int value)
        {
            damage = value;
            return this;
        }

        public ICharacterBuilder SetAI(bool value)
        {
            isAI = value;
            return this;
        }

        public Character Build()
        {
            return new Character(health, mana, damage, isAI);
        }
    }
}

public static class CharacterDirector
{
    public static Character BuildPlayer(ICharacterBuilder builder)
    {
        return builder
            .SetHealth(100)
            .SetMana(50)
            .SetDamage(10)
            .SetAI(false)
            .Build();
    }


    public static Character BuildEnemy(ICharacterBuilder builder)
    {
        return builder
            .SetHealth(200)
            .SetMana(0)
            .SetDamage(25)
            .SetAI(true)
            .Build();
    }

}


class Program
{
    static void Main()
    {
        ICharacterBuilder builder = new CharacterBuilder();

        Character player = CharacterDirector.BuildPlayer(builder);
        Character enemy = CharacterDirector.BuildEnemy(builder);

        player.Print();
        enemy.Print();

        Console.ReadKey();
    }
}
