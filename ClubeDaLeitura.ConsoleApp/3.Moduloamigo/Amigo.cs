using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal  class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string Nomeresponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public ArrayList HistoricoMultas { get; set; } = new ArrayList();

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
            throw new NotImplementedException();
        }
    }
}
