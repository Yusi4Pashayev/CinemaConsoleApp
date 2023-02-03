using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;


namespace CinemaConsoleApp.Services
{
    internal class HallManager : ICrudService
    {
        private CinemaManager _cinemaManager;
        private int _hallIndex = 0;
        private Hall[] halls = new Hall[10];



        public HallManager(CinemaManager cinemaManager)
        {
            _cinemaManager = cinemaManager;
        }

        public void Add(int cinemaId, Entity entity)
        {
            Hall hall = (Hall)entity;
            Cinema cinema = null;
            
            for (int i = 0; i < _cinemaManager.Cinemas.Length; i++)
            {
                if (_cinemaManager.Cinemas[i] == null)
                    continue;

                if (_cinemaManager.Cinemas[i].Id == cinemaId)
                   cinema = _cinemaManager.Cinemas[i];
            }


            if (cinema == null)
            {
                Console.WriteLine("Hal hazirda sistemde hec bir filial yoxdur");
                return;
            }

            for (int i = 0; i < cinema.Hall.Length; i++)
            {
                if (cinema.Hall[i] == null)
                {
                    cinema.Hall[i] = (Hall)entity;

                    
                    Console.WriteLine("Zall elave olundu!");
                    Console.WriteLine("-------------------------------------");
                    return;
                }
            }
            Console.WriteLine("butun zallar elave olunub. her cinemada yalniz 3 zal ola biler");

        }

        public void Delete(int id)
        {
            Cinema[] cinemas = (Cinema[])_cinemaManager.GetAll();

            for (int i = 0; i < cinemas.Length; i++)
            {
                for (int j = 0; j < cinemas[i].Hall.Length; j++)
                {
                    if (cinemas[i].Hall[j].Id == id)
                    {
                        cinemas[i].Hall[j] = null;
                        Console.WriteLine($"ID: {id} olan Zal silindi");
                        return;
                    }

                }
            }
            Console.WriteLine($"ID: {id} olan Zal hec bir filialda yoxdur ");
        }

        public Entity[] GetAll()
        {
            _hallIndex = 0;
            Cinema[] cinemas = (Cinema[])_cinemaManager.GetAll();

            for (int i = 0; i < cinemas.Length; i++)
            {
                if (cinemas[i] == null)
                {
                    continue;
                }
                for (int j = 0; j < cinemas[i].Hall.Length; j++)
                {
                    halls[_hallIndex] = cinemas[i].Hall[j];
                    _hallIndex++;
                }
            }

            return halls;
        }

        public Entity Get(int id)
        {
            Cinema[] cinemas = (Cinema[])_cinemaManager.GetAll();

            for (int i = 0; i < cinemas.Length; i++)
            {
                if (cinemas[i] == null)
                {
                    continue;
                }
                for (int j = 0; j < cinemas[i].Hall.Length; j++)
                {
                    if (cinemas[i].Hall[j] == null)
                    {
                        continue;
                    }
                    if (cinemas[i].Hall[j].Id == id)
                    {
                        return cinemas[i].Hall[j];
                    }
                }
            }
            return null;

        }

        public void Update(int id, Entity entity)
        {
            Cinema[] cinemas = (Cinema[])_cinemaManager.GetAll();

            for (int i = 0; i < cinemas.Length; i++)
            {
                for (int j = 0; j < cinemas[i].Hall.Length; j++)
                {
                    if (cinemas[i].Hall[j].Id == id)
                    {
                        cinemas[i].Hall[j] = (Hall)entity;
                        Console.WriteLine($"ID: {id} olan Zal melumatlari deyisdirildi");
                        return;
                    }

                }
            }
            Console.WriteLine($"ID: {id} olan Zal hec bir filialda yoxdur ");
        }
        public void Print()
        {
            Hall[] hallsForPrint = (Hall[])GetAll();
            Console.WriteLine($"{"BUTUN ZALLARIN SIYAHISI",30}");
            Console.WriteLine("-------------------------------------");

            foreach (var item in halls)
            {
                if (item == null)
                {
                    continue;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine("_____________________________________");
        }

        public void Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Print(int id)
        {
            Hall hallForPrint = (Hall)Get(id);
            if (hallForPrint == null)
            {
                Console.WriteLine("bu ID ile Zal movcud deyil.");
                return;
            }
            Console.WriteLine($"{"SECDIYINIZ ZAL",25}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(hallForPrint);
            
        }
    }
}
