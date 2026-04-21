/*
Factory Method Pattern, nesne oluşturma işlemini alt sınıflara bırakarak
nesne yaratma sürecini esnek hale getirir. Böylece istemci,
somut sınıfları bilmeden nesne oluşturabilir.
*/

namespace FactoryMethod
{

    public interface IWeapon
    {
        int Damage { get; }
        void Equip();
    }

    public class StandardWeapon : IWeapon
    {
        public int Damage => 5;

        public void Equip()
        {
            //Equip Weapon
        }
    }

    public class HolyWeapon : IWeapon
    {
        public int Damage => 100;

        public void Equip()
        {
            //Equip Weapon
        }
    }

    public class StandardWeaponFactory()
    {
        public IWeapon Create()
        {
            return new StandardWeapon();
        }
    }

    public class HolyWeaponFactory()
    {
        public IWeapon Create()
        {
            return new HolyWeapon();
        }
    }
}

public class Program()
{
    public static void Main()
    {
        StandardWeaponFactory standardWeaponFactory = new StandardWeaponFactory();
        StandardWeaponFactory holyWeaponFactory = new StandardWeaponFactory();

        var sWeapon = standardWeaponFactory.Create();
        var hWeapon = holyWeaponFactory.Create();


        Console.ReadKey();
    }
}
