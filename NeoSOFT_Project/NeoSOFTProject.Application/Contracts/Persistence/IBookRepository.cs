using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSOFTProject.Domain.Entities;

namespace NeoSOFTProject.Application.Contracts.Persistence
{
   public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
