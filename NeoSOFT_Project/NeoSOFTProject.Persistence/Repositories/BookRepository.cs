using Microsoft.EntityFrameworkCore;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Application.Exceptions;
using NeoSOFTProject.Domain.Entities;

namespace NeoSOFTProject.Persistence.Repositories
{
    class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                throw new NotFoundException($"Book with ID {id} not found.");
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Book.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Book.Include(b => b.Author)
                                                    .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                throw new NotFoundException($"Book with ID {id} not found.");

            return book;
        }

        public async Task UpdateBook(Book book)
        {
            var existingBook = await _context.Book.FindAsync(book.Id);

            if (existingBook == null)
                throw new NotFoundException($"Book with ID {book.Id} not found.");

            existingBook.Name = book.Name;
            existingBook.Price = book.Price;
            existingBook.Description = book.Description;

           
            await _context.SaveChangesAsync();
        }

    }
}
