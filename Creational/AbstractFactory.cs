/*
Abstract Factory Pattern, birbiriyle ilişkili nesne ailelerini
somut sınıflara bağımlı olmadan oluşturmayı sağlar. Böylece
nesne setleri tutarlı şekilde üretilir ve bağımlılıklar azaltılır.
*/

namespace AbstractFactory
{
    public interface IButton
    {
        void Render();
    }

    public interface ISlider
    {
        void Render();
    }

    public interface IPopup
    {
        void Render();
    }


    public class PCButton : IButton
    {
        public void Render() => Console.WriteLine("PC Button Rendered");
    }

    public class PCSlider : ISlider
    {
        public void Render() => Console.WriteLine("PC Slider Rendered");
    }

    public class PCPopup : IPopup
    {
        public void Render() => Console.WriteLine("PC Popup Rendered");
    }


    public class MobileButton : IButton
    {
        public void Render() => Console.WriteLine("Mobile Button Rendered");
    }

    public class MobileSlider : ISlider
    {
        public void Render() => Console.WriteLine("Mobile Slider Rendered");
    }

    public class MobilePopup : IPopup
    {
        public void Render() => Console.WriteLine("Mobile Popup Rendered");
    }


    public interface IUIFactory
    {
        IButton CreateButton();
        ISlider CreateSlider();
        IPopup CreatePopup();
    }


    public class PCUIFactory : IUIFactory
    {
        public IButton CreateButton() => new PCButton();
        public ISlider CreateSlider() => new PCSlider();
        public IPopup CreatePopup() => new PCPopup();
    }

    public class MobileUIFactory : IUIFactory
    {
        public IButton CreateButton() => new MobileButton();
        public ISlider CreateSlider() => new MobileSlider();
        public IPopup CreatePopup() => new MobilePopup();
    }


    public class UIManager
    {
        private readonly IButton button;
        private readonly ISlider slider;
        private readonly IPopup popup;

        public UIManager(IUIFactory factory)
        {
            button = factory.CreateButton();
            slider = factory.CreateSlider();
            popup = factory.CreatePopup();
        }

        public void Render()
        {
            button.Render();
            slider.Render();
            popup.Render();
        }
    }
}

class Program
{
    static void Main()
    {
        IUIFactory factory = new PCUIFactory();
        // IUIFactory factory = new MobileUIFactory();

        UIManager uiManager = new UIManager(factory);
        uiManager.Render();

        Console.ReadKey();
    }
}
