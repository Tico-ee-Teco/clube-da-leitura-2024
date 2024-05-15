using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal  class TelaAmigo : Telabase
    {        
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Pagar Multas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void PagarMulta()
        {
            ApresentarCabecalho();

            Console.WriteLine("Pagamento de Multas...");

            VisualizarAmigosComMulta();

            Console.WriteLine("Digite o id do amigo que deseja pagar a multa: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = (Amigo)repositorio.SelecionarPorId(idAmigo);

            Console.WriteLine($"O valor da multa é de: R$ {amigo.ValorMulta}?");
            Console.WriteLine("1 - Pagar");
            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcao = Console.ReadLine()[0];

            if (opcao == 'S' || opcao == 's')
                return;

            amigo.PagarMulta();

            ExibirMensagem($"Multas com o valor de R$ {amigo.ValorMulta} pagas com sucesso!", ConsoleColor.Green);
        }

        private void VisualizarAmigosComMulta()
        {
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -25} | {5, -10}",
                "Id", "Nome", "Responsável", "Telefone", "Endereço" ,"Multa R$"
            );

            ArrayList amigosCadastrados = ((RepositorioAmigo)repositorio).SelecionarAmigosComMulta();

            foreach (Amigo amigo in amigosCadastrados)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -25} | {5, -15}",
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco, amigo.ValorMulta
                );
            }

            Console.ReadLine();
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "Id", "Nome", "Nome responsavel", "Telefone", "Endereço"
                );

            ArrayList amigoscadastrados = repositorio.SelecionarTodos();

            foreach ( Amigo amigo in amigoscadastrados)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("digite o nome responsavel");
            string nomeresponsavel = Console.ReadLine();

            Console.WriteLine("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o Endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, telefone, nomeresponsavel, endereco);

            return amigo;
        }

        public void CadastraramigoTeste()
        {            
            Amigo amigo = new Amigo("Veloz", "999440807", "veloz2", "sao cristovao");
            repositorio.Cadastrar(amigo);

            Amigo amigo1 = new Amigo("cleber", "44794796", "Junior", "Santa maria");
            repositorio.Cadastrar(amigo1);

            Amigo amigo2 = new Amigo("Pedro", "685976956", "Maria", "Tributo");
            repositorio.Cadastrar(amigo2);
        }
      
    }
}
