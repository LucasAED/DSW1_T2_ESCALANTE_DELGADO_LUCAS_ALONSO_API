using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = null!; // "Active", "Returned"
        public DateTime CreatedAt { get; set; }

        // Propiedad de navegación para saber qué libro es
        public Book? Book { get; set; }
    }
}
