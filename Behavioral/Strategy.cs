/*
Strategy Pattern, bir davranışı farklı sınıflar halinde tanımlayıp
çalışma zamanında bu davranışlar arasında geçiş yapmayı sağlar.
Böylece if-else blokları yerine esnek ve genişletilebilir bir yapı elde edilir.
*/


namespace Strategy
{

    interface ICargoStrategy
    {
        int GetPrice();
    }

    class Product
    {
        public string Name { get; }
        public int Price { get; }
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class StandardCargoPayment : ICargoStrategy
    {
        private const int Price = 1;
        public int GetPrice()
        {
            Console.WriteLine("Standard Kargo ücreti $1 uygulandı");
            return Price;
        }
    }

    class FastCargoPayment : ICargoStrategy
    {
        private const int Price = 5;
        public int GetPrice()
        {
            Console.WriteLine("Hızlı Kargo ücreti $5 uygulandı");
            return Price;
        }
    }
    class InternationalCargoPayment : ICargoStrategy
    {
        private const int Price = 15;

        public int GetPrice()
        {
            Console.WriteLine("Uluslararası Kargo ücreti $10 uygulandı");
            return Price;
        }
    }

    class ShoppingCart
    {
        private List<Product> products;
        private ICargoStrategy cargoPayment;

        public ShoppingCart(ICargoStrategy cargoPayment)
        {
            this.products = new List<Product>();
            this.cargoPayment = cargoPayment;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!products.Contains(product))
                return;

            products.Remove(product);
        }
        public void ChangeCargoPayment(ICargoStrategy cargoPayment)
        {
            this.cargoPayment = cargoPayment;
        }

        public void Pay()
        {
            if (cargoPayment == null)
                throw new NullReferenceException("CargoStrategy is null");

            int totalPrice = 0;
            foreach (var item in products)
                totalPrice += item.Price;

            totalPrice += cargoPayment.GetPrice();

            Console.WriteLine($"Toplam {totalPrice} ödendi");
        }
    }
}

class Program
{
    public static void Main()
    {
        Product product1 = new Product("Product1", 5);
        Product product2 = new Product("Product2", 15);
        Product product3 = new Product("Product3", 25);

        ShoppingCart shoppingCart = new ShoppingCart(new StandardCargoPayment());
        shoppingCart.AddProduct(product1);
        shoppingCart.AddProduct(product2);
        shoppingCart.AddProduct(product3);

        shoppingCart.Pay();

        shoppingCart.ChangeCargoPayment(new FastCargoPayment());
        shoppingCart.RemoveProduct(product2);

        shoppingCart.Pay();


        Console.ReadKey();
    }
}
