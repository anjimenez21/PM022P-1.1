using SQLite;
using Tarea1._3.Models;

namespace Tarea1._3.Controlador
{
    public class Metodos
    {
        readonly SQLiteAsyncConnection _connection;

        public Metodos() { 
        }

        public Metodos(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Personas>().Wait();

        }

        public Task<int> AddPeople(Personas personas)
        {
            if (personas.Id == 0)
            {
                return _connection.InsertAsync(personas);
            }
            else
            {
                return _connection.UpdateAsync(personas);
            }
        }

        public Task<List<Personas>> GetListPople()
        {
            return _connection.Table<Personas>().ToListAsync();
        }

        public Task<Personas> GetPersonForId(int id)
        {
            return _connection.Table<Personas>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> delete(Personas personas)
        {
            return _connection.DeleteAsync(personas);
        }
    }
}
