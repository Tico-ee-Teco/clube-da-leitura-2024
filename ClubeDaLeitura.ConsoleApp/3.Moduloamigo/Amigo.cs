using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal class Amigo : EntidadeBase
    {

        public string Nome { get; set; }
        public string Nomeresponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Amigo() { }

        public Amigo(string nome, string telefone, string nomeresponsavel, string endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Nomeresponsavel = nomeresponsavel;
            Endereco = endereco;
        }

        public override ArrayList Validar()
        {
           
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Nomeresponsavel))
                erros.Add("O campo \"Nome responsavel\" é obrigatório");

            if (string.IsNullOrEmpty(Endereco))
                erros.Add("O campo \"Endereço\" é obrigatório");

            return erros;

        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo novasInformacoes = (Amigo)novoRegistro;

            this.Nome = novasInformacoes.Nome;
            this.Telefone = novasInformacoes.Telefone;
            this.Nomeresponsavel = novasInformacoes.Nomeresponsavel;
            this.Endereco = novasInformacoes.Endereco;
        }
    }
}
