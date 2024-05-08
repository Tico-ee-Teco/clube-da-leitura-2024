using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal  class Amigo : EntidadeBase
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

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone))
                erros[contadorErros++] = ("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Nomeresponsavel))
                erros[contadorErros++] = ("O campo \"Nome responsavel\" é obrigatório");

            if (string.IsNullOrEmpty(Endereco))
                erros[contadorErros++] = ("O campo \"Endereço\" é obrigatório");

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;


        }
    }
}
