using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Ports.Out
{
    public interface IBookRepository : IRepository<Book>
    {
        // Método extra para buscar por ISBN
        Task<Book?> GetByIsbnAsync(string isbn);
    }
}