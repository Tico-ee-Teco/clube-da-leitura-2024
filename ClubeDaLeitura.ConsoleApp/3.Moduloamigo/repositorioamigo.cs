using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Moduloamigo
{
    internal class RepositorioAmigo : Repositoriobase
    {
        public ArrayList SelecionarAmigosComMulta()
        {
            ArrayList amigosComMulta = new ArrayList();

            foreach (Amigo a in registros)
            {
                if (a.TemMulta)
                    amigosComMulta.Add(a);
            }

            return amigosComMulta;
        }
    }
}
