using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioAmigo repositorioamigo = new RepositorioAmigo();
            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioamigo;

            telaAmigo.CadastraramigoTeste();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            

            telaCaixa.CadastrarcaixaoTeste();

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevista;

            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa; 

            telaRevista.CadastrarRevistaTeste();

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                 Telabase  tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaAmigo;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;


                else if (opcaoPrincipalEscolhida == '3') 
                    tela = telaRevista;


                else if (opcaoPrincipalEscolhida == '4') ;



                else if (opcaoPrincipalEscolhida == '5') ;



                else if (opcaoPrincipalEscolhida == '6') ;



                    char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
                
            }
            Console.ReadLine();
        }
    }
}
