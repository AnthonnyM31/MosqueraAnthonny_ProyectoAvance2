using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static MosqueraAnthonny_TareaApuntes.NuevaNotaPage;

namespace MosqueraAnthonny_TareaApuntes;

public class BaseDeDatos
{
    private readonly SQLiteAsyncConnection _database;

    public BaseDeDatos(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Nota>().Wait();
    }

    public Task<List<Nota>> ObtenerNotasAsync()
    {
        return _database.Table<Nota>().ToListAsync();
    }

    public Task<int> GuardarNotaAsync(Nota nota)
    {
        return nota.Id != 0 ? _database.UpdateAsync(nota) : _database.InsertAsync(nota);
    }

    public Task<int> EliminarNotaAsync(Nota nota)
    {
        return _database.DeleteAsync(nota);
    }
}