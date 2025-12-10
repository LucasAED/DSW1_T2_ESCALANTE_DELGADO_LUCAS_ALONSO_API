using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Ports.Out;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LoanDto>> GetActiveLoansAsync()
        {
            var loans = await _unitOfWork.LoanRepository.GetActiveLoansAsync();
            return _mapper.Map<List<LoanDto>>(loans);
        }

        public async Task<LoanDto> RegisterLoanAsync(CreateLoanDto loanDto)
        {
            // 1. Validar que el libro exista
            var book = await _unitOfWork.BookRepository.GetByIdAsync(loanDto.BookId);
            if (book == null) throw new Exception("El libro no existe.");

            // 2. REGLA DE NEGOCIO: No prestar si stock es 0
            if (book.Stock <= 0) throw new Exception("No hay stock disponible para este libro.");

            // 3. Crear el préstamo
            var loan = _mapper.Map<Loan>(loanDto);
            loan.LoanDate = DateTime.Now;
            loan.Status = "Active";
            loan.CreatedAt = DateTime.Now;

            // 4. REGLA DE NEGOCIO: Disminuir Stock en 1
            book.Stock -= 1;

            // 5. Guardar todo usando UnitOfWork (Transacción implícita)
            await _unitOfWork.BookRepository.UpdateAsync(book);
            await _unitOfWork.LoanRepository.SaveAsync(loan);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<bool> ReturnLoanAsync(int loanId)
        {
            var loan = await _unitOfWork.LoanRepository.GetByIdAsync(loanId);
            if (loan == null) return false;

            if (loan.Status == "Returned") return false; // Ya fue devuelto

            // 1. Actualizar estado del préstamo
            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;

            // 2. Recuperar el libro asociado
            var book = await _unitOfWork.BookRepository.GetByIdAsync(loan.BookId);
            if (book != null)
            {
                // 3. REGLA DE NEGOCIO: Aumentar Stock en 1
                book.Stock += 1;
                await _unitOfWork.BookRepository.UpdateAsync(book);
            }

            await _unitOfWork.LoanRepository.UpdateAsync(loan);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}