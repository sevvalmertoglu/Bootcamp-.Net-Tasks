/*
Task.Run -> Asenkron bir görev başlatır.
Task.Factory.StartNew -> Görev başlatır ve yapılandırma seçenekleri sunar.
Task.WhenAll -> Tüm görevlerin tamamlanmasını bekler.
Task.WhenAny -> İlk tamamlanan görevi döner.
Task.FromResult -> Belirli bir sonuçla tamamlanmış görev oluşturur.
Task.FromException -> Hata ile tamamlanmış görev oluşturur.
Task.FromCanceled -> İptal edilmiş görev oluşturur.
Task.Delay -> Asenkron gecikme sağlar.
Task.Yield -> İş parçacığını serbest bırakır.
Task.CompletedTask -> Tamamlanmış boş görev.
Task.WaitAll -> Görevlerin tamamlanmasını senkron bekler.
Task.WaitAny -> İlk tamamlanan görevi senkron bekler.
*/
namespace TaskStaticMethodsExample
{
    public class TaskStaticMethods
    {
        public static async Task RunExamples()
        {
            Console.WriteLine("Task Static Methods Examples\n");

            // 1. Task.Run
            Console.WriteLine("1. Task.Run");
            await Task.Run(() => PerformTask("Task.Run example"));

            // 2. Task.Factory.StartNew
            Console.WriteLine("\n2. Task.Factory.StartNew");
            Task factoryTask = Task.Factory.StartNew(() => PerformTask("Task.Factory.StartNew example"));
            factoryTask.Wait();

            // 3. Task.WhenAll
            Console.WriteLine("\n3. Task.WhenAll");
            var task1 = PerformLongTask("Task 1", 2000);
            var task2 = PerformLongTask("Task 2", 3000);
            await Task.WhenAll(task1, task2);
            Console.WriteLine("All tasks completed.");

            // 4. Task.WhenAny
            Console.WriteLine("\n4. Task.WhenAny");
            var firstCompletedTask = await Task.WhenAny(task1, task2);
            Console.WriteLine("First task completed.");

            // 5. Task.FromResult
            Console.WriteLine("\n5. Task.FromResult");
            Task<int> completedTask = Task.FromResult(42);
            Console.WriteLine($"Result from Task.FromResult: {await completedTask}");

            // 6. Task.FromException
            Console.WriteLine("\n6. Task.FromException");
            Task failedTask = Task.FromException(new InvalidOperationException("An error occurred"));
            try
            {
                await failedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }

            // 7. Task.FromCanceled
            Console.WriteLine("\n7. Task.FromCanceled");
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            Task canceledTask = Task.FromCanceled(cancellationTokenSource.Token);
            Console.WriteLine("Canceled task created.");

            // 8. Task.Delay
            Console.WriteLine("\n8. Task.Delay");
            Console.WriteLine("Waiting for 2 seconds...");
            await Task.Delay(2000);
            Console.WriteLine("Wait completed.");

            // 9. Task.Yield
            Console.WriteLine("\n9. Task.Yield");
            Console.WriteLine("Before Task.Yield");
            await Task.Yield();
            Console.WriteLine("After Task.Yield");

            // 10. Task.CompletedTask
            Console.WriteLine("\n10. Task.CompletedTask");
            await Task.CompletedTask;
            Console.WriteLine("CompletedTask used.");

            // 11. Task.WaitAll
            Console.WriteLine("\n11. Task.WaitAll");
            var waitAllTask1 = PerformLongTask("WaitAll Task 1", 1000);
            var waitAllTask2 = PerformLongTask("WaitAll Task 2", 1500);
            Task.WaitAll(waitAllTask1, waitAllTask2);
            Console.WriteLine("All tasks in Task.WaitAll completed.");

            // 12. Task.WaitAny
            Console.WriteLine("\n12. Task.WaitAny");
            var waitAnyTask1 = PerformLongTask("WaitAny Task 1", 2000);
            var waitAnyTask2 = PerformLongTask("WaitAny Task 2", 1000);
            int completedTaskIndex = Task.WaitAny(waitAnyTask1, waitAnyTask2);
            Console.WriteLine($"Task.WaitAny completed: Task {completedTaskIndex + 1}");
        }

        private static void PerformTask(string taskName)
        {
            Console.WriteLine($"{taskName} is running...");
            Thread.Sleep(1000); // Simulate
            Console.WriteLine($"{taskName} completed.");
        }

        private static async Task PerformLongTask(string taskName, int delay)
        {
            Console.WriteLine($"{taskName} started...");
            await Task.Delay(delay);
            Console.WriteLine($"{taskName} completed.");
        }
    }
}
