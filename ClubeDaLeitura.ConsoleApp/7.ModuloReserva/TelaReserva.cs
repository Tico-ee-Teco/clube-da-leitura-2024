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

        public void Registar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Reserva entidade = (Reserva)ObterRegistro();

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

            Console.WriteLine("Digte o id do amigo");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorio.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);

            Console.WriteLine("Digite o id da revista");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorio.SelecionarPorId(idRevista);

            Reserva novaReserva = new Reserva(revistaSelecionada, amigoSelecionado);

            return novaReserva;

        }
    }
}
