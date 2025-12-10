using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de Libros
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();

            // Mapeo de Préstamos
            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : "Desconocido")); // Truco para mostrar el título del libro

            CreateMap<CreateLoanDto, Loan>();
        }
    }
}