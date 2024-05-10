using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : Telabase
    {
        public TelaCaixa telaCaixa = null;
        public RepositorioCaixa repositorioCaixa = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if(exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Revistas...");
            }

            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10} | {5, -10}",
               "Id", "Titulo", "Número Edição", "Ano", "Caixa", "Status Empréstimo"
           );

            ArrayList revistasCadastrados = repositorio.SelecionarTodos();

            foreach (Revista revista in revistasCadastrados)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                     "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10} | {5, -10}",
                     revista.Id, revista.Titulo, revista.NumeroEdicao, revista.Ano, revista.Caixa.Etiqueta, revista.StatusEmprestimo                    
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o Título da Revista: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o número da edição: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digte o ano da Revista: ");
            int anoRevista = Convert.ToInt32(Console.ReadLine());

            telaCaixa.VisualizarRegistros(false);

            Console.WriteLine("Digite o Id da caixa");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

            Console.WriteLine("Digite o valor da revista: ");
            decimal valorRevista = Convert.ToDecimal(Console.ReadLine());

            Revista novaRevista = new Revista(titulo, numeroEdicao, anoRevista, caixaSelecionada, valorRevista );

            return novaRevista;        }

        public void CadastrarRevistaTeste()
        {
            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarTodos()[0];

            Revista revista = new Revista("Lendários", 2, 2000, caixaSelecionada, 30);
            repositorio.Cadastrar(revista);
        }
    }
}
