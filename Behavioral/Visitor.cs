/*
Visitor Pattern, nesne sınıflarını değiştirmeden onlara yeni davranışlar eklemeyi
sağlayan bir davranışsal tasarım desenidir. İşlemler visitor sınıflarına taşınır
ve her element kendisini ziyaretçiye göndererek ilgili davranışın uygulanmasını sağlar.
*/

namespace Visitor
{

    interface IFileVisitor
    {
        void Visit(TextFile file);
        void Visit(ImageFile file);
    }

    abstract class FileElement
    {
        public string Name { get; }
        public string Extension { get; }
        public FileElement(string name, string metaData)
        {
            Name = name;
            Extension = metaData;
        }
        public abstract void Accept(IFileVisitor visitor);
    }

    class TextFile : FileElement
    {
        public TextFile(string name, string metaData) : base(name, metaData)
        {
        }

        public override void Accept(IFileVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class ImageFile : FileElement
    {
        public ImageFile(string name, string metaData) : base(name, metaData)
        {
        }

        public override void Accept(IFileVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class FilePrintVisitor : IFileVisitor
    {
        public void Visit(TextFile file)
        {
            Console.WriteLine($"{file.Name} File text printed");
        }

        public void Visit(ImageFile file)
        {
            Console.WriteLine($"{file.Name} File image printed");
        }

    }

    class CompressVisitor : IFileVisitor
    {
        public void Visit(TextFile file)
        {
            Console.WriteLine($"{file.Name} File compressed with textfile compres method");
        }

        public void Visit(ImageFile file)
        {
            Console.WriteLine($"{file.Name} File compressed with image compress method");
        }
    }
}

class Program
{
    public static void Main()
    {
        List<FileElement> files = new List<FileElement>();

        files.Add(new TextFile("TextFile", ".txt"));
        files.Add(new ImageFile("ImageFile", ".png"));

        var printVisitor = new FilePrintVisitor();
        var compressVisitor = new CompressVisitor();

        foreach (var file in files)
        {
            file.Accept(printVisitor);
            file.Accept(compressVisitor);
        }

        Console.ReadKey();
    }
}
