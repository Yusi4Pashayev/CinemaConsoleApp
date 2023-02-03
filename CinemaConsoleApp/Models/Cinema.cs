

namespace CinemaConsoleApp.Models
{
    internal class Cinema : Entity
    {
        internal string Name { get; set; }
        internal Hall[] Hall { get; set; } = new Hall[3];


        public override string ToString()
        {
            string hall = "";

            foreach (var item in Hall)
            {
                hall += item;
            }
            return $"{"Cinema ID:",10}{Id} {"Filial adi:",12}{Name} \n{"ZALLAR",15}{hall}\n";
        }
    }
}
