using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : Telabase
    {
        public TelaRevista telaRevista = null;

        public RepositorioRevista repositorioRevista = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}  ",
                "Id", "Etiqueta", "Cor", "Dias de emprestimo maximo" 
                );

            ArrayList caixascadastradas = repositorio.SelecionarTodos();

            foreach (Caixa caixa in caixascadastradas)
            {
                if (caixa == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} ", 
               caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite a Etiqueta da Caixa: ");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("digite a Cor Da caixa");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite o numero de dias maximo para emprestimos: ");
            int emprestimomaximo = Convert.ToInt32(Console.ReadLine());           

            Caixa caixa = new Caixa(etiqueta, cor, emprestimomaximo); 

            return caixa;
        }

        public void CadastrarcaixaoTeste()
        {
            Caixa caixa = new Caixa("Romance", "Vermelha", 3);
            repositorio.Cadastrar(caixa);
        }
    }
}
