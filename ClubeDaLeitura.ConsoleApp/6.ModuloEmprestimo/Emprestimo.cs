using ClubeDaLeitura.ConsoleApp._6.ModuloEmprestivo;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;



namespace ClubeDaLeitura.ConsoleApp 
{
    internal class Emprestimo : EntidadeBase
    {        
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; } 
        public DateTime DataEmprestino { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Concluido { get; set; }
        public Caixa Caixa { get; set; }
        public int DiasAtraso 
        {
            get
            { return (DataDevolucao - DataEmprestino).Days; }             
        }

        
        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
        
            Revista = revista;

            DataEmprestino = DateTime.Now;
            DataDevolucao = DataEmprestino.AddDays(Revista.Caixa.DiasEmprestimo);
            Concluido = false;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Emprestimo emprestimo = (Emprestimo)novoRegistro;

            this.Amigo = emprestimo.Amigo;
            this.Revista = emprestimo.Revista;
        }

       
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Amigo == null)
                erros.Add("O campo \"Amigo\" precisa ser preenchido");

            if (Revista == null)
                erros.Add("O campo \"Revista\" precisa ser preenchido");              
            
            return erros;
        }        

        public decimal CalcularMulta(int dias)
        {
            decimal valor = (Revista.ValorRevista * 0.10M);
            decimal multa = valor * dias;

            return multa;
        }

        public void IniciarEmprestimo()
        {
            Revista.Emprestar();
        }

        public void ConcluirEmprestimo()
        {
            Revista.Devolver();
            Concluido = true;
        }

        public Multa GeraMulta()
        {
            TimeSpan diferenca = DateTime.Now - DataDevolucao;
            decimal valorMulta = Revista.ValorRevista * diferenca.Days;
            Multa multaGerada = new Multa(valorMulta, DateTime.Now);
            Amigo.HistoricoMultas.Add(multaGerada);
            return multaGerada;
        }

      
    }
}

