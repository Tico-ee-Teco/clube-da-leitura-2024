using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
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
        public bool Concluido { get; set; } = false;
        public int DiasAtraso 
        {
            get
            { return (DataDevolucao - DataEmprestino).Days; }             
        }

        
        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestino)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestino = DateTime.Now;
            DataDevolucao = dataEmprestino.AddDays(revista.Caixa.DiasEmprestimo);                        
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

       
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Amigo == null)
                erros.Add("O amigo precisa ser preenchido");

            if (Revista == null)
                erros.Add("A revista precisa ser preenchida");              
            
            return erros;
        }        

        public decimal CalcularMulta(int dias)
        {
            decimal valor = (Revista.ValorRevista * 0.10M);
            decimal multa = valor * dias;

            return multa;
        }

        public void ConcluirEmprestimo()
        {
            Concluido = true;
        }

        public bool EstaAtrasado()
        {
            return DiasAtraso > 0;
        }

        public void FazerEmprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo)
        {
            ArrayList Emprestimos = new ArrayList();

            foreach (Emprestimo emprestimo in Emprestimos)
            {
                if (emprestimo.Amigo == amigo && !emprestimo.Concluido)
                {
                    Console.WriteLine("Nao e possível fazer um novo emprestimo para este amigo. Existe um emprestimo em aberto para ele.");
                }
            }

            Emprestimo novoEmprestimo = new Emprestimo(amigo, revista, dataEmprestimo);
            Emprestimos.Add(novoEmprestimo);
            Console.WriteLine("Emprestimo realizado com sucesso");
        }
    }
}

