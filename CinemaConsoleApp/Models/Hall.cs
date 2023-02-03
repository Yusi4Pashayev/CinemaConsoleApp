

namespace CinemaConsoleApp.Models
{
    
    internal class Hall : Entity
    {
        internal string Name { get; set; }
        internal int Row { get; set; }
        internal int Col { get; set; }
        public override string ToString()
        {

            return $"\n{"Zal ID:",-10} {Id,5} {"Zall:",-12} {Name} \n{"Yer sayi:",-12}{Row} x {Col} = {Row*Col}";
        }
    }
}
