using ClubeDaLeitura.ConsoleApp.Moduloamigo;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Multa
    {       
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool EstaPaga { get; set; }
        public Amigo Amigo { get; set; }        

        public Multa(decimal valor, DateTime data)
        {
            Valor = valor;
            Data = data; 
            
            EstaPaga = false;
        }

       public void PagarMulta()
       {
            EstaPaga = true;           
       }
        
    }
}