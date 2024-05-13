using ClubeDaLeitura.ConsoleApp._6.ModuloEmprestivo;
using ClubeDaLeitura.ConsoleApp._7.ModuloReserva;
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

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Emprestimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;

            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;

            telaEmprestimo.repositorioAmigo = repositorioamigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;

            RepositorioReserva repositorioReserva = new RepositorioReserva();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;

            telaReserva.telaAmigo = telaAmigo;
            telaReserva.telaRevista = telaRevista;

            telaReserva.repositorioAmigo = repositorioamigo;
            telaReserva.repositorioRevista = repositorioRevista;


            while (true)
            {
   
                    char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                    if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    {
                        break;
                    }

                    else if (OpcaoInvalida(opcaoPrincipalEscolhida))
                    {
                        Mensagemdeerro();
                    
                        continue;
                    }


                    Telabase tela = null;

                    if (opcaoPrincipalEscolhida == '1')
                        tela = telaAmigo;

                    else if (opcaoPrincipalEscolhida == '2')
                        tela = telaCaixa;


                    else if (opcaoPrincipalEscolhida == '3')
                        tela = telaRevista;


                    else if (opcaoPrincipalEscolhida == '4')
                    {
                      tela = telaReserva;

                     char operacaoescolhidareserva = tela.apresentarmenureservas();

                     if (operacaoescolhidareserva == 'S' || operacaoescolhidareserva == 's')
                        continue;

                    if (operacaoescolhidareserva == '1')
                       tela.Registrar();

                    else if (operacaoescolhidareserva == '2')
                        tela.Editar();

                    else if (operacaoescolhidareserva == '3')
                        tela.Excluir();

                    else if (operacaoescolhidareserva == '4')
                        tela.VisualizarRegistros(true);

                    if (operacaoescolhidareserva == '5')
                      tela = telaEmprestimo;

                    }
                        

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
     
            static bool OpcaoInvalida(char validacao)
            {
                string opcoesValidas = "12345";
                return !opcoesValidas.Contains(validacao.ToString());
            }

            static void Mensagemdeerro()
            {

                Console.WriteLine("Digite uma opcao valida");

                Console.ReadLine();

            }

           

        }
    }
}

