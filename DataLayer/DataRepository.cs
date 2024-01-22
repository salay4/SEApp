using BE;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    // DAL: DataAccessLayer project
    public class DataRepository : IDataRepositoryProvider
    {
        private readonly AppDbContext _context;

        public DataRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<List<CurrencyPair>> GetCurrencyPairsAsync()
        {
            return await _context.CurrencyPairs.ToListAsync();
        }

        public async Task UpdateCurrencyPairMinMaxValueAsync(string pairName, decimal minValue, decimal maxValue)
        {
            var currencyPair = await _context.CurrencyPairs.FirstOrDefaultAsync(cp => cp.PairName == pairName);

            if (currencyPair != null)
            {
                currencyPair.MinValue = minValue;
                currencyPair.MaxValue = maxValue;

                await _context.SaveChangesAsync();
            }
        }

        public async Task LoadDataAsync()
        {
            // Load data from the Currency and CurrencyPair tables if needed
            var currencies = await GetCurrenciesAsync();
            var currencyPairs = await GetCurrencyPairsAsync();

            // Perform further operations as needed
        }

        public async Task SaveCurrencyPairMinMaxValueAsync(string pairName, decimal minValue, decimal maxValue)
        {
            await UpdateCurrencyPairMinMaxValueAsync(pairName, minValue, maxValue);
        }

        public async Task CheckAndInitializeTablesAsync()
        {
            if (!await _context.Database.CanConnectAsync())
            {
                // Database doesn't exist or cannot be connected
                // Create the database and apply migrations
                await _context.Database.Migrate();
            }

            // Check if Currency table exists
            if (!_context.Currencies.Any())
            {
                // Generate random data for Currency table
                await GenerateRandomCurrencyDataAsync();
            }

            // Check if CurrencyPair table exists
            if (!_context.CurrencyPairs.Any())
            {
                // Generate random data for CurrencyPair table
                await GenerateRandomCurrencyPairDataAsync();
            }
        }


        private async Task GenerateRandomCurrencyDataAsync()
        {
            // Generate and add random Currency data
            // Add your logic here to generate random Currency data
            // Example:
            var randomCurrencies = new List<Currency>
        {
            new Currency { Country = "United States", CurrencyName = "US Dollar", CurrencyAbbreviation = "USD" },
            new Currency { Country = "European Union", CurrencyName = "Euro", CurrencyAbbreviation = "EUR" },
            new Currency { Country = "Israel", CurrencyName = "Shekel", CurrencyAbbreviation = "ILS" },
            new Currency { Country = "United Kingdom", CurrencyName = "Pound", CurrencyAbbreviation = "GBP" },
            // Add more currencies as needed
        };

            _context.Currencies.AddRange(randomCurrencies);
            await _context.SaveChangesAsync();
        }

        private async Task GenerateRandomCurrencyPairDataAsync()
        {
            // Get all currencies
            var currencies = await _context.Currencies.ToListAsync();

            // Generate and add random CurrencyPair data
            var randomCurrencyPairs = new List<CurrencyPair>();

            // Create pairs for each combination of currencies
            for (int i = 0; i < currencies.Count; i++)
            {
                for (int j = i + 1; j < currencies.Count; j++)
                {
                    // PairName format: "CURRENCY_A/CURRENCY_B"
                    var pairName = $"{currencies[i].CurrencyAbbreviation}/{currencies[j].CurrencyAbbreviation}";

                    // Generate random values for MinValue and MaxValue
                    var minValue = (decimal)new Random().NextDouble();
                    var maxValue = minValue + (decimal)new Random().NextDouble();

                    var currencyPair = new CurrencyPair
                    {
                        PairName = pairName,
                        MinValue = minValue,
                        MaxValue = maxValue
                    };

                    randomCurrencyPairs.Add(currencyPair);
                }
            }

            // Add generated currency pairs to the database
            _context.CurrencyPairs.AddRange(randomCurrencyPairs);
            await _context.SaveChangesAsync();
        }

    }
}
