using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal  class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public ArrayList HistoricoMultas { get; set; } = new ArrayList();
        public bool TemMulta
        {
            get
            {
                for (int i = 0; i < HistoricoMultas.Count; i++)
                {
                    Multa multa = (Multa)HistoricoMultas[i];

                    if (!multa.EstaPaga)
                        return true;
                }

                return false;
            }
        }

        public decimal ValorMulta
        {
            get
            {
                decimal valor = 0;

                for (int i = 0; i < HistoricoMultas.Count; i++)
                {
                    Multa multa = (Multa)HistoricoMultas[i];

                    if (!multa.EstaPaga)
                        valor += multa.Valor;
                }

                return valor;
            }
        }

        public Amigo() { }

        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
       
        public void AdicionarEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }

       
        public void RemoverEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Remove(emprestimo);
        }

        public Amigo(string nome, string telefone, string nomeResponsavel, string endereco)
        {
            Nome = nome;
            Telefone = telefone;
            NomeResponsavel = nomeResponsavel;
            Endereco = endereco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();            

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(NomeResponsavel))
                erros.Add("O campo \"Nome responsavel\" é obrigatório");

            if (string.IsNullOrEmpty(Endereco))
                erros.Add("O campo \"Endereço\" é obrigatório");          

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo amigo = (Amigo)novoRegistro;

            this.Nome = amigo.Nome;
            this.Telefone = amigo.Telefone;
            this.NomeResponsavel = amigo.NomeResponsavel;
            this.Endereco = amigo.Endereco;
        }

        public void Multar(Multa multa)
        {
            HistoricoMultas.Add(multa);
        }

        public void PagarMulta()
        {
            for (int i = 0; i < HistoricoMultas.Count; i++)
            {
                Multa multa = (Multa)HistoricoMultas[i];

                if (!multa.EstaPaga)
                    multa.Pagar();
            }
        }
    }
}
