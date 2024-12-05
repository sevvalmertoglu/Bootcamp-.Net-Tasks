using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    public class OrderProcessor
    {
        public async Task ProcessOrderAsync()
        {
            try
            {
                var foodTask = PrepareFoodAsync("Pasta", 5);
                var drinkTask = PrepareDrinkAsync("Coffee", 2);

                // Tüm işlemlerin tamamlanmasını bekliyoruz
                await Task.WhenAll(foodTask, drinkTask);

                Console.WriteLine("Order is ready!");
                Console.WriteLine($"Food: {foodTask.Result}");
                Console.WriteLine($"Drink: {drinkTask.Result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private async Task<string> PrepareFoodAsync(string foodName, int preparationTime)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < preparationTime; i++)
                {
                    Console.WriteLine($"{foodName} - Cooking step {i + 1}");
                    Thread.Sleep(1000); // 1 second delay
                }
                return $"{foodName} is ready.";
            });
        }

        private async Task<string> PrepareDrinkAsync(string drinkName, int preparationTime)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < preparationTime; i++)
                {
                    Console.WriteLine($"{drinkName} - Preparing step {i + 1}");
                    Thread.Sleep(1000);
                }
                return $"{drinkName} is ready.";
            });
        }
    }
}
