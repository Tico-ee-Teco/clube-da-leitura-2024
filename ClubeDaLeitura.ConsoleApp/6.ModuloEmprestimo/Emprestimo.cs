using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp 
{
    internal class Emprestimo : EntidadeBase
    {
        //ToDo
        //Cada amigo só pode pegar uma revista por empréstimo.
        //Mensalmente Gustavo verifica os empréstimos realizados no mês e diariamente os empréstimos que estão em aberto.
        //Calcular data de Devolução baseando-se na Caixa da Revista
        //Cobrar Multa para Devoluções atrasadas
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestino { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool StatusEmprestimo { get; set; }
        public int DiasAtraso 
        {
            get
            { return (DataDevolucao - DataEmprestino).Days; }             
        }


        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestino, DateTime dataDevolucao, bool statusEmprestimo)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestino = DateTime.Now;
            DataDevolucao = dataDevolucao;
            StatusEmprestimo = statusEmprestimo;            
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularMulta(int dias)
        {
            decimal valor = (Revista.ValorRevista * 0.10M);
            decimal multa = valor * dias;

            return multa;
        }
    }
}

    