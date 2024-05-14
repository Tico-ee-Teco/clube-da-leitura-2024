using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp._6.ModuloEmprestivo
{
    internal class RepositorioEmprestimo : Repositoriobase
    {
        internal ArrayList SelecionarEmprestimosDoMes()
        {
            ArrayList emprestimosDoMes = new ArrayList();

            foreach (Emprestimo e in registros)
            {
                if (e.DataEmprestino.Month == DateTime.Today.Month)
                    emprestimosDoMes.Add(e);
            }

            return emprestimosDoMes;
        }

        internal ArrayList SelecionarEmprestimosDoDia()
        {
            ArrayList emprestimosDoDia = new ArrayList();

            foreach (Emprestimo e in SelecionarEmprestimosEmAberto())
            {
                if (e.DataEmprestino.Month == DateTime.Today.Month && e.DataEmprestino.Day == DateTime.Today.Day)
                    emprestimosDoDia.Add(e);
            }

            return emprestimosDoDia;
        }

        internal ArrayList SelecionarEmprestimosEmAberto()
        {
            ArrayList empretimosDoMes = new ArrayList();

            foreach (Emprestimo emprestimo in registros)
            {
                if(emprestimo.Concluido ==false)
                    empretimosDoMes.Add(emprestimo);
            }
            return empretimosDoMes;
        }
    }
}
