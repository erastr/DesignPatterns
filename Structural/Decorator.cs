/*
Decorator Pattern, bir nesnenin davranışını alt sınıf oluşturmadan
dinamik olarak genişletmeyi sağlar. Süreç, nesnenin etrafını saran
decorator nesneleriyle ek sorumluluk ekleme mantığıyla işler.
*/


namespace Decorator
{

    public interface IAttack
    {
        void Attack();
    }

    public class SwordAttack : IAttack
    {
        public void Attack()
        {
            //Attack
        }
    }

    public abstract class AttackBaseDecorator : IAttack
    {
        protected IAttack attack;

        public AttackBaseDecorator(IAttack attack)
        {
            this.attack = attack;
        }

        public virtual void Attack()
        {
            attack.Attack();
        }
    }

    public class FireBuffDecorator : AttackBaseDecorator
    {
        public FireBuffDecorator(IAttack attack) : base(attack)
        {
        }

        public override void Attack()
        {
            attack.Attack();
            // Add FireBuff
        }
    }

    public class PoisonBuffDecorator : AttackBaseDecorator
    {
        public PoisonBuffDecorator(IAttack attack) : base(attack)
        {
        }

        public override void Attack()
        {
            attack.Attack();
            // Add PoisonBuff
        }
    }

    public class IceBuffDecorator : AttackBaseDecorator
    {
        public IceBuffDecorator(IAttack attack) : base(attack)
        {
        }

        public override void Attack()
        {
            attack.Attack();
            // Add IceBuff
        }
    }
}





public class Program
{
    public static void Main()
    {
        IAttack attack = 
            new FireBuffDecorator(
                new IceBuffDecorator(
                    new SwordAttack()));
        
        attack.Attack();

        Console.ReadKey();
    }
}
