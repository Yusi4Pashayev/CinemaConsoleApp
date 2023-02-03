

using System.Globalization;

namespace CinemaConsoleApp.Models
{
    internal class Film : Entity
    {
        internal string Name { get; set; }
        internal string Genre { get; set; }
        internal string Director { get; set; }
        internal int Time { get; set; }

        public override string ToString()
        {
            int hour = Time / 60;
            int minute = Time % 60;
            return $"{"Film ID:",-10}{Id}\n{"Film adi:",-10}{Name}\n{"Janr:",-10}{Genre}\n{"Direktor:",-10}{Director}\n{"Muddet:",-10}{hour} saat {minute} deqiqe\n ";
        }

    }
}
