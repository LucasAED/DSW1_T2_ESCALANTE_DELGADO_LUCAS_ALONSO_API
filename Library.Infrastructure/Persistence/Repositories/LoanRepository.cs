using Library.Domain.Entities;
using Library.Domain.Ports.Out;
using Library.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Loan>> GetActiveLoansAsync()
        {
            // Incluimos los datos del libro (Join) para mostrar el título
            return await _context.Loans
                .Include(l => l.Book)
                .Where(l => l.Status == "Active")
                .ToListAsync();
        }
    }
}
