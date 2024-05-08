using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public int Ano { get; set; }
        //public Caixa Caixa { get; set; }
        public bool StatusEmprestimo { get; set; }

        public Revista() { }

        public Revista(string titulo, int numeroEdicao, int ano, bool statusEmprestimo)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            //Caixa = caixa;
            StatusEmprestimo = statusEmprestimo;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("Favor digitar um Título.");

            if (NumeroEdicao < 0)
                erros.Add("Digite um numero de edição válido.");

            if (Ano < 0)
                erros.Add("Digite um ano válido.");

            if (StatusEmprestimo == null)
                erros.Add("Favor definir um status (s ou n)");

            return erros;

        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista novasInformacoes = (Revista)novoRegistro;

            this.Titulo = novasInformacoes.Titulo;
            this.NumeroEdicao = novasInformacoes.NumeroEdicao;
            this.Ano = novasInformacoes.Ano;
            this.StatusEmprestimo = novasInformacoes.StatusEmprestimo;
        }
    }
}