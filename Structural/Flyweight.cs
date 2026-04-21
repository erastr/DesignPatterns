/*
Flyweight Pattern, çok sayıda küçük nesnenin oluşturulması gerektiğinde
paylaşılan ortak durumlarla bellek kullanımını azaltır. Nesnenin içsel
ve dışsal durumlarını ayırarak verimlilik sağlar.
*/

namespace Flyweight
{

    public class SoldierBase //Flyweight -> Shared - Intrinsic State
    {
        private string mesh;
        private string texture;

        public SoldierBase(string mesh, string texture)
        {
            this.mesh = mesh;
            this.texture = texture;
        }
    }

    public class Soldier //Context Non-Shared Extrinsic State
    {
        private string name;
        private int coordinateX;
        private int coordinateY;
        private SoldierBase soldierBase;

        public Soldier(string name, int coordinateX, int coordinateY, SoldierBase soldierBase)
        {
            this.name = name;
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
            this.soldierBase = soldierBase;
        }

        public void Move(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
            Console.WriteLine($"Soldier Moving To X:{coordinateX} - Y{coordinateY}");
        }
    }

    public class SoldierBaseFactory //Factory
    {
        Dictionary<(string, string), SoldierBase> cacheDic = new();


        public SoldierBase Create(string mesh, string texture)
        {
            var key = (mesh, texture);

            if (cacheDic.ContainsKey(key))
                return cacheDic[key];

            SoldierBase soldierBase = new SoldierBase(mesh, texture);
            cacheDic.Add(key, soldierBase);

            return soldierBase;

        }
    }
}

public class Program
{
    public static void Main()
    {
        SoldierBaseFactory factory = new SoldierBaseFactory();
        var soldierBase = factory.Create("mesh1","texture1");
        var soldierBase2 = factory.Create("mesh2", "texture2");

        Soldier soldier = new Soldier("Alex", 1, 1, soldierBase);
        Soldier soldier1 = new Soldier("Jeff", 1, 1, soldierBase);
        Soldier soldier2 = new Soldier("Leon", 1, 1, soldierBase2);
        Soldier soldier3 = new Soldier("David", 1, 1, soldierBase2);


        Console.ReadKey();
    }
}
