using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {

        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public string DiasEmprestimo { get; set; }
       

        public Caixa() { }

        public Caixa(string etiqueta, string cor, string diasemprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasemprestimo;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Etiqueta))
                erros[contadorErros++] = ("O campo \"Etiqueta\" é obrigatório");

            if (string.IsNullOrEmpty(Cor))
                erros[contadorErros++] = ("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(DiasEmprestimo))
                erros[contadorErros++] = ("O campo \"Dias de emprestimo\" é obrigatório");


            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;


        }
    }
}
