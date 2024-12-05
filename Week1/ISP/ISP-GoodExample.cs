namespace Week1_ISP.GoodExample
{
    public interface IRun
    {
        void Run();
    }

    public interface IFly
    {
        void Fly();
    }

    public interface ISwim
    {
        void Swim();
    }

    public class Dog : IRun, ISwim
    {
        public void Run()
        {
            Console.WriteLine("Dog is running");
        }

        public void Swim()
        {
            Console.WriteLine("Dog is swimming");
        }
    }

    public class Bird : IRun, IFly
    {
        public void Run()
        {
            Console.WriteLine("Bird is running");
        }

        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    // Balık sadece yüzer
    public class Fish : ISwim
    {
        public void Swim()
        {
            Console.WriteLine("Fish is swimming");
        }
    }

}