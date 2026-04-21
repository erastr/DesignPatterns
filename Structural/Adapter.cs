/*
Adapter Pattern, uyumsuz arayüzlere sahip sınıfların birlikte çalışmasını sağlayan
bir dönüştürücü görevi görür. Mevcut sınıfları değiştirmeden yeni bir arayüz üzerinden
kullanmamıza olanak tanır.
*/

namespace Adapter
{

    public interface IPaymentService
    {
        void Pay(decimal amount);
    }

    public class OldPaymentSystem
    {
        public void MakePayment(double totalPrice)
        {
            Console.WriteLine($"Old system paid {totalPrice} TL");
        }
    }

    public class OldPaymentAdapter : IPaymentService
    {
        private readonly OldPaymentSystem oldPaymentSystem;

        public OldPaymentAdapter(OldPaymentSystem oldPaymentSystem)
        {
            this.oldPaymentSystem = oldPaymentSystem;
        }

        // BURAYI SEN DOLDUR
        public void Pay(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Amount must bigger then 0");

            oldPaymentSystem.MakePayment((double)amount);
        }
    }
}

public class Program
{
    public static void Main()
    {
        IPaymentService paymentService =
           new OldPaymentAdapter(new OldPaymentSystem());

        paymentService.Pay(150.75m);

        Console.ReadKey();
    }
}
