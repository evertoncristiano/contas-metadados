using System;
using System.ComponentModel.DataAnnotations;

namespace ContasApi.ViewModels
{
    public class CriarContaViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal ValorOriginal { get; set; }
        [Required]
        public DateTime DataDeVencimento { get; set; }
        [Required]
        public DateTime DataDePagamento { get; set; }
    }
}