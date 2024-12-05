namespace AsynchronousProgramming.AsynchronousExample
{
    public class AsynchronousApiProcessor
    {
        private readonly ApiService _apiService;

        public AsynchronousApiProcessor(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task FetchData()
        {
            Console.WriteLine("Asynchronous API processing started...");

            var weatherTask = _apiService.FetchDataAsynchronously("Weather API");
            var currencyTask = _apiService.FetchDataAsynchronously("Currency API");

            var weatherData = await weatherTask;
            Console.WriteLine(weatherData);

            var currencyData = await currencyTask;
            Console.WriteLine(currencyData);

            Console.WriteLine("Asynchronous API processing completed.");
        }
    }
}