using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Domain.Entities;

namespace NeoSOFTProject.Persistence.Repositories
{
    class AuthorRepository : IAuthorRepository
    {
        public Task<Author> AddAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author?> GetAuthorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
