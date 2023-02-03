

namespace CinemaConsoleApp.Models
{
    
    internal class Hall : Entity
    {
        internal string Name { get; set; }

        internal string[,] seats;
        public override string ToString()
        {

            return $"\n{"Zal ID:",-10} {Id,5} {"Zall:",-12} {Name} \n{"Yer sayi:",-12}{seats.GetLength(0)} x {seats.GetLength(1)} = {seats.GetLength(0)*seats.GetLength(1)}";
        }
    }
}
