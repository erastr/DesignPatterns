/*
Template Method Pattern, bir algoritmanın iskeletini bir üst sınıfta tanımlar 
ve bazı adımların alt sınıflar tarafından özelleştirilmesine izin verir. 
Algoritmanın genel akışı sabittir, yalnızca adımlar değiştirilebilir.
*/
namespace TemplateMethod
{
    abstract class BaseReport
    {
        public object GetReport()
        {
            var data = GetData();
            var processedData = ProcessData(data);
            var report = CreateReport(processedData);
            SaveReport(report);

            return new object();
        }

        protected virtual object ProcessData(object data)
        {
            Console.WriteLine("Data İşleniyor...");
            return new object();
        }

        protected virtual object CreateReport(object processedData)
        {
            Console.WriteLine("Rapor oluşturuluyor");
            return new object();
        }

        protected virtual void SaveReport(object report)
        {
            Console.WriteLine("Rapor kaydedildi");
        }

        protected abstract object GetData();

    }

    class SalesReporter : BaseReport
    {
        protected override object GetData()
        {
            Console.WriteLine("Satış verisini getir...");
            return new object();
        }
    }

    class InventoryReporter : BaseReport
    {
        protected override object GetData()
        {
            Console.WriteLine("Envanter verisini getir...");
            return new object();
        }
    }
}

class Program
{
    public static void Main()
    {
        BaseReport salesReporter = new SalesReporter();
        var salesReport = salesReporter.GetReport();
        BaseReport inventoryReporter = new InventoryReporter();
        var inventoryReport = inventoryReporter.GetReport();

        Console.ReadKey();
    }
}
