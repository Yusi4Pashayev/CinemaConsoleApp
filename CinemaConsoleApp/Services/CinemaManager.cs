using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;



namespace CinemaConsoleApp.Services
{
    public class CinemaManager : ICrudService
    {
        private int _cinemaIndex = 0;
        internal Cinema[] Cinemas { get; set; } = new Cinema[4];

        public void Add(Entity entity)
        {
            if (_cinemaIndex > 2)
            {
                Console.WriteLine("Maximum 3 Cinema Elave etmek olar!");
                return;
            }
            Cinemas[_cinemaIndex++] = (Cinema)entity;
            Console.WriteLine($"{entity.Id} Id-li Cinema elave olundu");
            Console.WriteLine("-------------------------------------");
        }

        public void Delete(int id)
        {
            bool found = false;

            for (int i = 0; i < Cinemas.Length; i++)
            {
                if (Cinemas[i] == null)
                    continue;

                if (Cinemas[i].Id == id)
                {
                    found = true;

                    for (int j = i; j < Cinemas.Length - 1; j++)
                    {
                        Cinemas[j] = Cinemas[j + 1];
                    }

                    _cinemaIndex--;
                    Console.WriteLine($"ID: {id}, Cinema silindi!");
                    return;
                }
            }
            if (!found)
                Console.WriteLine($"ID: {id}, Cinema tapilmadi");
        }

        public Entity[] GetAll()
        {
            return Cinemas;
        }

        public Entity Get(int id)
        {
            for (int i = 0; i < Cinemas.Length; i++)
            {
                if (Cinemas[i] == null)
                    continue;

                if (Cinemas[i].Id == id)
                    return Cinemas[i];
            }
            Console.WriteLine("Cinema tapilmadi");
            return null;
        }

        public void Update(int id, Entity entity)
        {
            for (int i = 0; i < Cinemas.Length; i++)
            {
                if (Cinemas[i] == null)
                    continue;

                if (Cinemas[i].Id == id)
                    Cinemas[i] = (Cinema)entity;
            }
        }
        public void Print()
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"{"BUTUN FILIALLARIN SIYAHISI",30}");
            Console.WriteLine("------------------------------------");
            foreach (var item in Cinemas)
            {
                if (item == null)
                    continue;

                Console.WriteLine(item);
                Console.WriteLine("_____________________________________");
            }
        }
    }
}
