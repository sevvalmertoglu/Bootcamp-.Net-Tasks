namespace Week1_ISP.BadExample
{
    public interface IAnimal
    {
        void Run();
        void Fly();
        void Swim();
    }

    public class Dog : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Dog is running");
        }

        public void Fly()
        {
            // Köpek uçamaz
            throw new NotSupportedException("Dog cannot fly.");
        }

        public void Swim()
        {
            Console.WriteLine("Dog is swimming");
        }
    }

    public class Bird : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Bird is running");
        }

        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }

        public void Swim()
        {
            // Kuş yüzemez
            throw new NotSupportedException("Bird cannot swim.");
        }
    }
}