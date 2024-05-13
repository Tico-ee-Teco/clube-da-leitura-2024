using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Moduloamigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Reserva : EntidadeBase
    {        
        public DateTime DataReserva;
        public Revista Revista { get; set; }
        public Amigo Amigo { get; set; }
        public bool Expirada { get; set; } = false;

        public Reserva( Revista revista, Amigo amigo, DateTime dataReserva)
        {
            DataReserva = dataReserva;
            Revista = revista;
            Amigo = amigo;           
        }        

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Amigo == null)
                erros.Add("O amigo precisa ser preenchido");

            if (Revista == null)
                erros.Add("A revista precisa ser preenchida");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public void Expirar()
        {
            Expirada = true;
        }

        public bool EstaExpirando()
        {
            return (DateTime.Now - DataReserva).TotalDays > 2;
        }
    }
}