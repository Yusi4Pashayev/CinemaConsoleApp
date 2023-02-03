using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;


namespace CinemaConsoleApp.Services
{
    internal class FilmManager : ICrudService
    {
        private int _filmIndex = 0;
        internal Film[] Films { get; set; } = new Film[11];
        
        public void Add(Entity entity)
        {
            
            if (_filmIndex > 9)
            {
                Console.WriteLine("Maximum 10 Film Elave etmek olar!");
                return;
            }
            Films[_filmIndex++] = (Film)entity;
            Console.WriteLine("Film elave olundu");
        }

        public void Delete(int id)
        {
            bool found = false;

            for (int i = 0; i < Films.Length; i++)
            {
                if (Films[i] == null)
                    continue;

                if (Films[i].Id == id)
                {
                    found = true;

                    for (int j = i; j < Films.Length - 1; j++)
                    {
                        Films[j] = Films[j + 1];
                    }

                    _filmIndex--;
                    Console.WriteLine($"ID: {id}, Film silindi!");
                    return;
                }

            }
            if (!found)
                Console.WriteLine($"ID: {id}, Film tapilmadi");
        }

        public Entity[] GetAll()
        {
            return Films;
        }

        public Entity Get(int id)
        {
            for (int i = 0; i < Films.Length; i++)
            {
                if (Films[i] == null)
                    continue;

                if (Films[i].Id == id)
                    return Films[i];
            }
            Console.WriteLine("Film tapilmadi");
            return null;
        }

        public void Update(int id, Entity entity)
        {
            for (int i = 0; i < Films.Length; i++)
            {
                if (Films[i] == null)
                    continue;


                if (Films[i].Id == id)
                {
                    Films[i] = (Film)entity;
                    Console.WriteLine("Film melumati deyisdirildi");
                    Console.WriteLine("______________________________");
                    return;
                }
            }
            Console.WriteLine("Bu ID de Film yoxdur");
            Console.WriteLine("______________________________");
        }
        public void Print()
        {
            Console.WriteLine("______________________________");
            Console.WriteLine($"{"BUTUN FILMLERIN SIYAHISI",27}");
            Console.WriteLine("------------------------------");
            foreach (var item in Films)
            {
                if (item == null)
                    continue;

                Console.WriteLine(item);
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine("______________________________");
        }
        
    }
}
