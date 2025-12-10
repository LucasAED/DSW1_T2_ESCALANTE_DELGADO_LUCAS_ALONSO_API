using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Ports.Out
{
    public interface ILoanRepository : IRepository<Loan>
    {
        // Método extra para listar préstamos activos
        Task<List<Loan>> GetActiveLoansAsync();
    }
}
