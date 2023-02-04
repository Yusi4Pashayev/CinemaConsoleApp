

namespace CinemaConsoleApp.Models
{
    internal class Session : Entity
    {
        internal Cinema Cinema { get; set; }
        internal Hall Hall { get; set; }
        internal Film Film { get; set; }
        internal string[,] seats { get; set; }
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal int Price { get; set; }

        public override string ToString()
        {
            return $"{"Filial ID:",-12}{Cinema.Id,-5}{"Filial Adi:",-12}{Cinema.Name}\n" +
                $"{"Zall ID:",-12}{Hall.Id,-5}{"Zall Adi:",-12}{Hall.Name}\n{"Filma ID:",-12}{Film.Id,-5}{"FIlm Adi:",-12}{Film.Name}\n" +
                $"{"Baslama vaxti:",-12}{StartTime}\n{"Bitme vaxti:",-12}{EndTime}\n{"Qiymeti:",-12}{Price} AZN";
        }
    }
}
