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
                
        public override void Registrar()
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

        public void Concluir()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            VisualizarEmprestimosEmAberto();

            Console.WriteLine("Digite o id do emprestimo que deseja concluir: ");
            int idEmprestimo = Convert.ToInt32( Console.ReadLine());

            Emprestimo emprestimo = (Emprestimo)repositorio.SelecionarPorId(idEmprestimo);

            emprestimo.ConcluirEmprestimo();

            DateTime dataHoje = DateTime.Now;

            if (dataHoje > emprestimo.DataDevolucao)
            {
                Multa multa = emprestimo.GeraMulta();

                ExibirMensagem($"Uma multa de R$ {multa.Valor} foi gerada.", ConsoleColor.DarkYellow);
            }

            ExibirMensagem($"O emprestimo foi concluído com sucesso!.", ConsoleColor.Green);
        }

        public void RegistrarEmprestimoDeReserva(Reserva reserva)
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Emprestimo entidade = new Emprestimo(reserva.Amigo, reserva.Revista);

            entidade.IniciarEmprestimo();

            base.InserirRegistro(entidade);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Empréstimos...");

            Console.WriteLine();

            Console.WriteLine("1 - Visualizar Empréstimos do Mês");
            Console.WriteLine("2 - Visualizar Empréstimos Em Aberto do Dia");
            Console.WriteLine("3 - Visualizar Todos os Empréstimos");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine()[0];

            ArrayList emprestimos;

            if (opcaoEscolhida == '1')
                emprestimos = ((RepositorioEmprestimo)repositorio).SelecionarEmprestimosDoMes();

            else if (opcaoEscolhida == '2')
                emprestimos = ((RepositorioEmprestimo)repositorio).SelecionarEmprestimosDoDia();

            else
                emprestimos = repositorio.SelecionarTodos();

            VisualizarEmprestimos(emprestimos);

            Console.ReadLine();
        }

        private void VisualizarEmprestimos(ArrayList emprestimos)
        {
            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -20} | {3, -10} | {4, -10} | {5, -20}",
               "Id", "Nome do Amigo", "Titulo da revista", "Data de Emprestimo", "Data de Devolução", "Status"
           );

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo == null)
                    continue;

                string statusEmprestimo = emprestimo.Concluido ? "Concluído" : "Em Aberto";

                Console.WriteLine(
                     "{0, -10} | {1, -20} | {2, -20} | {3, -10} | {4, -10} | {5, -20}",
                     emprestimo.Id,
                     emprestimo.Amigo.Nome,
                     emprestimo.Revista.Titulo,
                     emprestimo.DataEmprestino.ToShortDateString(),
                     emprestimo.DataDevolucao.ToShortDateString(),
                     statusEmprestimo 
                );
            }

            Console.ReadLine();
           
        }

        private void VisualizarEmprestimosEmAberto()
        {
            Console.WriteLine();

            Console.WriteLine(
              "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -20}",
              "Id", "Revista", "Amigo", "Data", "Data de Devolução", "Status"
          );

            ArrayList registros = ((RepositorioEmprestimo)repositorio).SelecionarEmprestimosEmAberto();

            foreach (Emprestimo e in registros)
            {
                if(e == null) continue;

                string statusEmprestimo = e.Concluido ? "Concluído" : "Em Aberto";

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -20}",
                    e.Id, e.Revista.Titulo, e.Amigo.Nome, e.DataEmprestino.ToShortDateString(), e.DataDevolucao.ToShortDateString(), statusEmprestimo
                ); 
            }

            Console.ReadLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            while (true)
            {
                telaAmigo.VisualizarRegistros(false);

              Console.WriteLine("Digite o id do amigo: ");
              int idAmigo = Convert.ToInt32(Console.ReadLine());

              Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

           

                if (amigoSelecionado.Emprestimos.Any(emprestimo => !emprestimo.Concluido && emprestimo.DataDevolucao > DateTime.Now))
                {

                    Console.WriteLine("Este Amigo já possui um empréstimo em aberto. Escolha outro amigo.");

                    List<Amigo> amigosSemEmprestimos = new List<Amigo>();

                    foreach (Amigo amigo in repositorioAmigo.SelecionarTodos())
                    {
                        if (!amigo.Emprestimos.Any(emprestimo => !emprestimo.Concluido && emprestimo.DataDevolucao > DateTime.Now))
                        {
                            amigosSemEmprestimos.Add(amigo);
                        }
                    }

                    Console.WriteLine();

                    Console.WriteLine("Amigos disponiveis:");

                    foreach (Amigo amigo in amigosSemEmprestimos)
                    {

                        Console.WriteLine($"ID: {amigo.Id}  Nome: {amigo.Nome}");
                    }
                    Console.WriteLine();

                    Console.WriteLine("Digite o ID Do amigo que deseja escolher: ");
                    int idAmigoSelecionado = Convert.ToInt32(Console.ReadLine());

                    amigoSelecionado = amigosSemEmprestimos.FirstOrDefault(amigo => amigo.Id == idAmigoSelecionado);

                }
                if (amigoSelecionado.TemMulta)
                {
                    Console.WriteLine("Este Amigo já possui uma multa em aberto. Escolha outro amigo.");
                    Console.ReadLine();
                    continue;

                }

                telaRevista.VisualizarRegistros(false);

                Console.Write("Digite o ID da revista: ");
                int idRevista = Convert.ToInt32(Console.ReadLine());

                Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

                Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

                amigoSelecionado.AdicionarEmprestimo(novoEmprestimo);

                return novoEmprestimo;
            }
        }

        public void CadastrarEmprestimoTeste()
        {
            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarTodos()[0];
            Revista revistaSelecianada = (Revista)repositorioRevista.SelecionarTodos()[0];

            Emprestimo emprestimo = new Emprestimo(amigoSelecionado, revistaSelecianada);

            repositorio.Cadastrar(emprestimo);
        }


    }


}
