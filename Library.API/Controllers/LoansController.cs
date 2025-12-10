using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveLoans()
        {
            var loans = await _loanService.GetActiveLoansAsync();
            return Ok(loans);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterLoan(CreateLoanDto loanDto)
        {
            try
            {
                var loan = await _loanService.RegisterLoanAsync(loanDto);
                return Ok(loan); // Devuelve 200 si hay stock y se creó
            }
            catch (Exception ex)
            {
                // Devuelve 400 Bad Request si no hay stock (Regla de negocio)
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint para Devolver Libro (Equivalente funcional a "DarBaja" de un préstamo)
        [HttpPost("return/{id}")]
        public async Task<IActionResult> ReturnLoan(int id)
        {
            var result = await _loanService.ReturnLoanAsync(id);
            if (!result) return BadRequest(new { message = "No se pudo devolver. Verifique el ID o si ya fue devuelto." });

            return Ok(new { message = "Libro devuelto con éxito. Stock actualizado." });
        }
    }
}