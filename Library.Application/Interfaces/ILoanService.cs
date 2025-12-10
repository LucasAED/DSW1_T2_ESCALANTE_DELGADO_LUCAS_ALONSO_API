using Library.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface ILoanService
    {
        Task<LoanDto> RegisterLoanAsync(CreateLoanDto loanDto); // Regla: Bajar Stock
        Task<bool> ReturnLoanAsync(int loanId); // Regla: Subir Stock
        Task<List<LoanDto>> GetActiveLoansAsync();
    }
}