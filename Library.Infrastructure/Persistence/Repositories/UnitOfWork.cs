using Library.Domain.Ports.Out;
using Library.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository BookRepository { get; }
        public ILoanRepository LoanRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository, ILoanRepository loanRepository)
        {
            _context = context;
            BookRepository = bookRepository;
            LoanRepository = loanRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}