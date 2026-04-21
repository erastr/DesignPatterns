/*
Bridge Pattern, soyutlama ile implementasyonu birbirinden ayırarak
iki hiyerarşinin bağımsız şekilde genişletilebilmesini sağlar.
Bu sayede sınıf patlaması önlenir ve esnek bir yapı elde edilir.
*/

namespace Bridge
{

    public interface IAbility
    {
        void Use();
    }

    public class Dash : IAbility
    {
        public void Use()
        {

        }
    }

    public class Hash : IAbility
    {
        public void Use()
        {

        }
    }
    public class Fireball : IAbility
    {
        public void Use()
        {

        }
    }


    public abstract class AbilityInputSystem
    {
        protected IAbility ability;

        protected AbilityInputSystem(IAbility ability)
        {
            this.ability = ability;
        }

        public void UseAbility()
        {
            ability.Use();
        }
    }

    public class PlayerInputSystem : AbilityInputSystem
    {
        public PlayerInputSystem(IAbility ability) : base(ability) { }
    }
    public class AIInputSystem : AbilityInputSystem
    {

        public AIInputSystem(IAbility ability) : base(ability) { }

        public int GetClosestTargetID()
        {
            //Calculate Closest Target 
            return 1;
        }
    }

    public class NetworkInputSystem : AbilityInputSystem
    {

        public NetworkInputSystem(IAbility ability) : base(ability) { }

        public int GetPing()
        {
            //Some calculation
            return 40;
        }
    }
}


public class Program
{
    public static void Main()
    {
        IAbility ability = new Dash();

        AbilityInputSystem inputSystem = new PlayerInputSystem(ability);
        inputSystem.UseAbility();

        Console.ReadKey();
    }
}
