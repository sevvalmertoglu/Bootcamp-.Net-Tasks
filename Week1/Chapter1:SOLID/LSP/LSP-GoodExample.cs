namespace Week1_LSP.GoodExample
{
    public abstract class Animal
    {
        public abstract void Move();
    }

    public interface ISoundMakingAnimal
    {
        void MakeSound();
    }

    public class Dog : Animal, ISoundMakingAnimal
    {
        public override void Move()
        {
            Console.WriteLine("Dog is running");
        }

        public void MakeSound()
        {
            Console.WriteLine("Dog is barking");
        }
    }

    public class Fish : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Fish is swimming");
        }
    }
}
