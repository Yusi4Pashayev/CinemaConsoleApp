using CinemaConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaConsoleApp.Services.Contacts
{
    internal interface ICrudService
    {
        public void Add(Entity entity);
        public void Update(int id, Entity entity);
        public void Delete(int id);
        public Entity Get(int id);
        public Entity[] GetAll();

    }
}
