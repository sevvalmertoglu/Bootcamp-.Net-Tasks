using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        Task<int> CompleteAsync();
    }
}