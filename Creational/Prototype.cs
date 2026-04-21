/*
Prototype Pattern, mevcut bir nesnenin klonlanarak yeni bir nesne oluşturulmasını sağlar.
Nesne yaratma maliyetinin yüksek olduğu durumlarda performans kazandırır.
Derin veya yüzeysel kopyalama ile yapı esnekleştirilebilir.
*/

namespace Prototype
{
    public interface IPrototype<T>
    {
        T Clone();
    }

    public class Skill : IPrototype<Skill>
    {
        public string Name { get; }
        public int ManaCost { get; }
        public List<string> Effects { get; }

        public Skill(string name, int manaCost, List<string> effects)
        {
            Name = name;
            ManaCost = manaCost;
            Effects = effects;
        }

        public Skill Clone()
        {
            // Deep copy
            return new Skill(
                Name,
                ManaCost,
                new List<string>(Effects)
            );
        }

        public void Print()
        {
            Console.WriteLine(
                $"{Name} | Mana:{ManaCost} | Effects:{string.Join(",", Effects)}"
            );
        }
    }
}

class Program
{
    static void Main()
    {
        Skill fireball = new Skill(
            "Fireball",
            10,
            new List<string> { "Burn", "Splash" }
        );

        Skill cloneFireball = fireball.Clone();

        cloneFireball.Effects.Add("Explosion");

        fireball.Print();
        cloneFireball.Print();

        Console.WriteLine(
            ReferenceEquals(fireball, cloneFireball)
                ? "Wrong Prototype"
                : "Correct Prototype"
        );

        Console.ReadKey();
    }
}
