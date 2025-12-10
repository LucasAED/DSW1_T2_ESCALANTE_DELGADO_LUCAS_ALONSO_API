using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Ports.Out
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        ILoanRepository LoanRepository { get; }
        Task<int> SaveChangesAsync();
    }
}