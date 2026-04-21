/*
    State Pattern: Bir nesnenin davranışını, iç durumuna bağlı olarak değiştirmesine
    olanak sağlayan davranışsal bir tasarım desenidir. Her durum (state) kendi davranışını
    uygular ve context üzerinden diğer state'e geçişi yönetir.
*/

namespace State
{

    interface IState<T>
    {
        void HandleState(T item);
    }

    class Character
    {
        private IState<Character> state;

        public Character(IState<Character> state)
        {
            this.state = state;
        }

        public void SetState(IState<Character> state)
        {
            this.state = state;
        }

        public void PerformAction()
        {
            state.HandleState(this);
        }
    }

    class IdleState : IState<Character>
    {
        public void HandleState(Character item)
        {
            Console.WriteLine("Character State: Idle");
            item.SetState(new WalkingState());
        }
    }

    class WalkingState : IState<Character>
    {
        public void HandleState(Character item)
        {
            Console.WriteLine("Character State: Walking");
            item.SetState(new AttackingState());
        }
    }

    class AttackingState : IState<Character>
    {
        public void HandleState(Character item)
        {
            Console.WriteLine("Character State: Attacking");
            item.SetState(new IdleState());
        }
    }
}


class Program
{
    public static void Main()
    {
        Character character = new Character(new IdleState());

        character.PerformAction();
        character.PerformAction();
        character.PerformAction();
        

        Console.ReadKey();
    }
}
