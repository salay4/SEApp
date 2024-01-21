// BusinessLogic.cs in BLL
using BE;
using DataLayer;

namespace BLL
{
    // BusinessLogicLayer project
    public class BusinessLogic
    {
        private readonly IDataRepositoryProvider _dataRepositoryProvider;

        public BusinessLogic(IDataRepositoryProvider dataRepositoryProvider)
        {
            _dataRepositoryProvider = dataRepositoryProvider ?? throw new ArgumentNullException(nameof(dataRepositoryProvider));
        }

        public async Task EmulateTradesAsync()
        {
            // Emulate trades and change the values of trading pairs randomly every 2 seconds
            while (true)
            {
                // Simulate random changes in trading pair values
                var random = new Random();
                var pairName = GetRandomPairName();
                var minValue = (decimal)random.NextDouble() * 10;
                var maxValue = minValue + (decimal)random.NextDouble() * 10;

                // Retrieve all currency pairs from the database
                var currencyPairs = await _dataRepositoryProvider.GetCurrencyPairsAsync();

                // Check if the minimum or maximum values have changed
                var existingPair = currencyPairs.FirstOrDefault(cp => cp.PairName == pairName);
                if (existingPair != null && (existingPair.MinValue != minValue || existingPair.MaxValue != maxValue))
                {
                    // Save the updated data to the database using DataLayer functions
                    await _dataRepositoryProvider.UpdateCurrencyPairMinMaxValueAsync(pairName, minValue, maxValue);
                }

                // Wait for 2 seconds before the next iteration
                Thread.Sleep(2000);
            }
        }

        private string GetRandomPairName()
        {
            // Implement logic to get a random pair name (e.g., USD/ILS, EUR/USD, GBP/ILS)
            // You can customize this based on your requirements
            var pairNames = new[] { "USD/ILS", "EUR/USD", "GBP/ILS" };
            var random = new Random();
            return pairNames[random.Next(pairNames.Length)];
        }

        public async Task<List<CurrencyPair>> GetRealTimeTradingData()
        {
            return await _dataRepositoryProvider.GetCurrencyPairsAsync();
        }
    }
}
