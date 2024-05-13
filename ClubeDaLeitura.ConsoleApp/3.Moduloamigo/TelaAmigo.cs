using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal  class TelaAmigo : Telabase
    {        
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
                amigo.Id, amigo.Nome, amigo.Nomeresponsavel, amigo.Telefone, amigo.Endereco
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
        }
    }
}
