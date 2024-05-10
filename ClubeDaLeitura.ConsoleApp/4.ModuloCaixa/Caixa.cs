using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
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

        public Caixa(string etiqueta, string cor, string diasemprestimo ) 
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasemprestimo;
            
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();            

            if (string.IsNullOrEmpty(Etiqueta))
                erros.Add("O campo \"Etiqueta\" é obrigatório");

            if (string.IsNullOrEmpty(Cor))
                erros.Add("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(DiasEmprestimo))
                erros.Add("O campo \"Dias de emprestimo\" é obrigatório");

            //Adicionar revista            

            return erros;


        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
