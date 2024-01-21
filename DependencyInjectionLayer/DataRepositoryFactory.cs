using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionLayer
{
    public class DataRepositoryFactory
    {
        private readonly AppDbContext _context;

        public DataRepositoryFactory(AppDbContext context)
        {
            _context = context;
        }

        public DataRepository Create()
        {
            return new DataRepository(_context);
        }
    }
}
