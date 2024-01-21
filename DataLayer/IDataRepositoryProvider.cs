using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
