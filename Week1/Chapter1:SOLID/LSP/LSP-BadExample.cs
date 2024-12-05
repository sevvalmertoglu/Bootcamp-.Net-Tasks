namespace Week1_LSP.BadExample
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal is making a sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog is barking");
        }
    }

    public class Fish : Animal
    {
        public override void MakeSound()
        {
            throw new NotSupportedException("Fish cannot make a sound.");
        }
    }
}
