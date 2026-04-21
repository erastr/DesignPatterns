/*
Composite Pattern, nesneleri ağaç yapısı şeklinde hiyerarşik olarak düzenler
ve bu yapıyı tekil nesne gibi kullanmayı sağlar. Böylece istemci,
yaprak ve bileşik nesneleri aynı arayüzle yönetebilir.
*/

namespace Composite
{

    public interface IArmyUnit
    {
        void Move();
        void Attack();
        void TakeDamage();
    }


    public class Knight : IArmyUnit
    {
        public void Attack()
        {

        }

        public void Move()
        {

        }

        public void TakeDamage()
        {

        }
    }

    public class Archer : IArmyUnit
    {
        public void Attack()
        {

        }

        public void Move()
        {

        }

        public void TakeDamage()
        {

        }
    }

    public class Mage : IArmyUnit
    {
        public void Attack()
        {

        }

        public void Move()
        {

        }

        public void TakeDamage()
        {

        }
    }

    public class SquadArmy : IArmyUnit
    {
        private List<IArmyUnit> armies = new();

        public void AddArmy(IArmyUnit army)
        {
            if (army == null)
                throw new ArgumentNullException(nameof(army));

            armies.Add(army);
        }

        public void RemoveArmy(IArmyUnit army)
        {
            armies.Remove(army);
        }

        public void Attack()
        {
            foreach (var army in armies)
            {
                army.Attack();
            }
        }

        public void Move()
        {
            foreach (var army in armies)
            {
                army.Move();
            }
        }

        public void TakeDamage()
        {
            foreach (var army in armies)
            {
                army.TakeDamage();
            }
        }
    }
}




public class Program
{
    public static void Main()
    {
        SquadArmy mainArmy = new SquadArmy();
        Archer archer = new Archer();
        Mage mage = new Mage();
        Knight knight = new Knight();
        SquadArmy squadArmy = new SquadArmy();
        SquadArmy squadArmy2 = new SquadArmy();
        squadArmy.AddArmy(mage);
        squadArmy.AddArmy(archer);
        squadArmy2.AddArmy(knight);
        mainArmy.AddArmy(squadArmy);
        mainArmy.AddArmy(squadArmy2);

        mainArmy.Attack();
        

        Console.ReadKey();
    }
}
