using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {

        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }
        public ArrayList Revistas { get; set; } = new ArrayList();
       

        public Caixa() { }

        public Caixa(string etiqueta, string cor, int diasemprestimo) 
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasemprestimo;   
           
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();            

            if (string.IsNullOrEmpty(Etiqueta))
                erros.Add("O campo \"Etiqueta\" é obrigatório.");

            if (string.IsNullOrEmpty(Cor))
                erros.Add("O campo \"Telefone\" é obrigatório.");

            if (DiasEmprestimo < 0)
                erros.Add("O campo \"Dias de emprestimo\" precisa ter um valor maior que zero.");            

            return erros;

        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
