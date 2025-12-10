using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class CreateLoanDto
    {
        public int BookId { get; set; }
        public string StudentName { get; set; } = string.Empty;
    }
}