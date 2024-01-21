using BE;

namespace DataLayer
{
    public interface IDataRepositoryProvider
    {
        Task<List<Currency>> GetCurrenciesAsync();
        Task<List<CurrencyPair>> GetCurrencyPairsAsync();
        Task UpdateCurrencyPairMinMaxValueAsync(string pairName, decimal minValue, decimal maxValue);
        Task LoadDataAsync();
        Task SaveCurrencyPairMinMaxValueAsync(string pairName, decimal minValue, decimal maxValue);
    }
}
