using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp._6.ModuloEmprestivo
{
    internal class TelaEmprestimo : Telabase
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;

        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;

        public void Registar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Emprestimo entidade = (Emprestimo)ObterRegistro();

            ArrayList erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            base.InserirRegistro(entidade);            
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Emprestimos...");
            }

            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
               "Id", "Nome do Amigo", "Titulo da revista", "Data de Emprestimo"
           );

            ArrayList emprestimoCadastrados = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimoCadastrados)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                     "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
                     emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.DataEmprestino
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);

            Console.WriteLine("Digite o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorio.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);

            Console.WriteLine("Digite o número da edição: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorio.SelecionarPorId(idRevista);

            Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada, DateTime.Now);

            return novoEmprestimo;
        }


    }

    
}
