using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE;

namespace DataLayer
{
    // DAL: DataAccessLayer project
    public class DataRepository
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
    }
}
