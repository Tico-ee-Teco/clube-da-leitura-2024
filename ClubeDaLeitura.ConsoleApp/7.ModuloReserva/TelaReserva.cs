using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp._7.ModuloReserva
{
    internal class TelaReserva : Telabase
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;

        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;      

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Reservas...");
            }

            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
               "Id", "Nome do Amigo", "Titulo da revista", "Data da Reserva", "Status Expiração"
           );

            ArrayList reservaCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservaCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine(
                     "{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
                     reserva.Id, reserva.Amigo.Nome, reserva.Revista.Titulo, reserva.DataReserva, reserva.Expirada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);

            Console.Write("Digte o id do amigo: ");
            int idAmigoSelecionado = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigoSelecionado);

            telaRevista.VisualizarRegistros(false);

            Console.Write("Digite o id da revista: ");
            int idRevistaSelecionada = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevistaSelecionada);

            Reserva novaReserva = new Reserva(revistaSelecionada, amigoSelecionado, DateTime.Now);

            return novaReserva;

        }
    }
}
