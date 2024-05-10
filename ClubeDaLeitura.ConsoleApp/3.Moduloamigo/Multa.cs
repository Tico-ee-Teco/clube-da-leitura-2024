using ClubeDaLeitura.ConsoleApp.Moduloamigo;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Multa
    {       
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool EstaPaga { get; set; } = false;
        public Amigo Amigo { get; set; }        

        public Multa(decimal valor, Amigo amigo)
        {
            Valor = valor;
            Amigo = amigo;          
        }

       public void PagarMulta()
       {
            EstaPaga = true;
            Amigo.TemMultaEmAberto = false; //Atualizar o ostatus do amigo
       }
        
    }
}