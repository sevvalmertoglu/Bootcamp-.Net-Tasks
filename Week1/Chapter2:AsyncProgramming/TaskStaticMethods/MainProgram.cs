namespace TaskStaticMethodsExampleRunner
{
    class MainProgram
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Running Task Static Methods Examples...\n");

            await TaskStaticMethodsExample.TaskStaticMethods.RunExamples();

            Console.WriteLine("\nAll Task examples have been executed.");
        }
    }
}

