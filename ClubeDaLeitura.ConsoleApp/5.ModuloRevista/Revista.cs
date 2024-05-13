using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public int Ano { get; set; }
        public bool StatusEmprestimo { get; set; }
        public decimal ValorRevista { get; set; }
        public Caixa Caixa { get; set; }


        public Revista() { }

        public Revista(string titulo, int numeroEdicao, int ano, Caixa caixa, decimal valorRevista)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            Caixa = caixa;
            ValorRevista = valorRevista;

            StatusEmprestimo = false;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("Favor digitar um Título.");

            if (NumeroEdicao < 0)
                erros.Add("Digite um numero de edição válido.");

            if (Ano < 1)
                erros.Add("Digite um ano válido.");

            if (Caixa == null)
                erros.Add("Digite insira a caixa da resvista");

            if (Caixa == null)
                erros.Add("Insira uma caixa válida.");

            if (ValorRevista < 1)
                erros.Add("Favor inserir um valor válido.");

            return erros;

        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista novasInformacoes = (Revista)novoRegistro;

            this.Titulo = novasInformacoes.Titulo;
            this.NumeroEdicao = novasInformacoes.NumeroEdicao;
            this.Ano = novasInformacoes.Ano;
            this.Caixa = novasInformacoes .Caixa;
            this.StatusEmprestimo = novasInformacoes.StatusEmprestimo;
        }

        public void Emprestar()
        {
            StatusEmprestimo = true;
        }

        public void Devolver()
        {
            StatusEmprestimo = false;
        }
    }
}