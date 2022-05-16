using ContasApi.ViewModels;
using System;

namespace ContasApi.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public DateTime DataDePagamento { get; set; }
        public int DiasDeAtraso { get; set; }
        public decimal ValorCorrigido { get; set; }
        public string RegraDeAtraso { get; set; }

        public Conta()
        {
        }

        public Conta(CriarContaViewModel conta)
        {
            Nome = conta.Nome;
            ValorOriginal = conta.ValorOriginal;
            DataDeVencimento = conta.DataDeVencimento;
            DataDePagamento = conta.DataDePagamento;
            DiasDeAtraso = CalcularDiasDeAtraso(DataDeVencimento, DataDePagamento);
            ValorCorrigido = CalcularValorCorrigido(ValorOriginal, DiasDeAtraso);
            RegraDeAtraso = BuscaRegraDeAtraso(DiasDeAtraso);
        }

        public int CalcularDiasDeAtraso(DateTime dataDeVencimento, DateTime dataDePagamento)
        {
            int DiasDeAtraso = (dataDePagamento.Subtract(dataDeVencimento)).Days;

            if (DiasDeAtraso > 0)
                return DiasDeAtraso;

            return 0;
        }

        public decimal CalcularValorCorrigido(decimal valorOriginal, int diasDeAtraso)
        {
            decimal valor = valorOriginal;

            if (diasDeAtraso > 0)
            {
                decimal multa = 0;
                decimal juros = 0;

                if (diasDeAtraso <= 3)
                {
                    multa = 2;
                    juros = 0.1M;
                }
                else if (diasDeAtraso <= 10)
                {
                    multa = 3;
                    juros = 0.2M;
                } else 
                {
                    multa = 5;
                    juros = 0.3M;
                }

                valor += (valorOriginal * multa) / 100;
                valor += ((valorOriginal * juros) / 100) * diasDeAtraso;
            }

            return valor;
        }

        public string BuscaRegraDeAtraso(int diasDeAtraso)
        {
            if (diasDeAtraso == 0)
                return null;

            if (diasDeAtraso < 3)
                return "Multa de 2% + Juros de 0,1% ao dia";

            if (diasDeAtraso < 10)
                return "Multa de 3% + Juros de 0,2% ao dia";

            return "Multa de 5% + Juros de 0,3% ao dia";
        }
    }
}