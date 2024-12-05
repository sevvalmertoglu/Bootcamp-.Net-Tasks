namespace AsynchronousProgramming.SynchronousExample
{
    public class SynchronousApiProcessor
    {
        private readonly ApiService _apiService;

        public SynchronousApiProcessor(ApiService apiService)
        {
            _apiService = apiService;
        }

        public void FetchData()
        {
            Console.WriteLine("Synchronous API processing started...");
            var weatherData = _apiService.FetchDataSynchronously("Weather API");
            Console.WriteLine(weatherData);

            var currencyData = _apiService.FetchDataSynchronously("Currency API");
            Console.WriteLine(currencyData);

            Console.WriteLine("Synchronous API processing completed.");
        }
    }
}