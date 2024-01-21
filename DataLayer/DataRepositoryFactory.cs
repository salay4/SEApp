namespace DataLayer
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
