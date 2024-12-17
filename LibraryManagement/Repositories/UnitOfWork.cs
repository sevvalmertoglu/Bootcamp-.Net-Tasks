using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LibraryContext _context;
        public IRepository<Book> Books { get; private set; }

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            Books = new Repository<Book>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}