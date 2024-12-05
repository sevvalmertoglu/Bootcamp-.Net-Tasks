public class ApiService
{
    public string FetchDataSynchronously(string apiName)
    {
        Console.WriteLine($"Fetching data from {apiName} (synchronously)...");
        Thread.Sleep(3000); // 3 saniyelik gecikme
        return $"{apiName} data";
    }

    public async Task<string> FetchDataAsynchronously(string apiName)
    {
        Console.WriteLine($"Fetching data from {apiName} (asynchronously)...");
        await Task.Delay(3000); 
        return $"{apiName} data";
    }
}
