using ContasApi.Models;
using System;
using Xunit;

namespace Contas.Tests
{
    public class ContaTest
    {
        [Fact]
        public void DiasDeAtrasoDeveSerZeroParaPagamentosAntesDoVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-05-06");
            DateTime DataDePagamento = DateTime.Parse("2022-01-01");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(0, conta.DiasDeAtraso);
        }

        [Fact]
        public void DiasDeAtrasoDeveSerZeroParaPagamentosNaDataDeVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-04-01");
            DateTime DataDePagamento = DateTime.Parse("2022-04-01");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(0, conta.DiasDeAtraso);
        }

        [Fact]
        public void DiasDeAtrasoDeveSerMaiorQueZeroParaPagamentosAposDataDeVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-04-01");
            DateTime DataDePagamento = DateTime.Parse("2022-04-11");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(10, conta.DiasDeAtraso);
        }

        [Fact]
        public void ValorCorrigidoDeveSerIgualAoValorOriginalParaPagamentosAntesDoVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-04-01");
            DateTime DataDePagamento = DateTime.Parse("2022-03-11");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(100, conta.ValorCorrigido);
        }

        [Fact]
        public void ValorCorrigidoDeveSerIgualAoValorOriginalParaPagamentosNoDiaDeVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-04-01");
            DateTime DataDePagamento = DateTime.Parse("2022-04-01");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(100, conta.ValorCorrigido);
        }

        [Fact]
        public void ValorCorrigidoDeveMaiorQueOValorOriginalParaPagamentosAposOVencimento()
        {
            DateTime DataDeVencimento = DateTime.Parse("2022-04-01");
            DateTime DataDePagamento = DateTime.Parse("2022-04-11");

            Conta conta = new Conta(new ContasApi.ViewModels.CriarContaViewModel { Nome = "Conta", ValorOriginal = 100, DataDeVencimento = DataDeVencimento, DataDePagamento = DataDePagamento });

            Assert.Equal(105, conta.ValorCorrigido);
        }
    }
}
