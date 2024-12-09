using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static MosqueraAnthonny_ProyectoAvance2.DiarioPage;

namespace MosqueraAnthonny_ProyectoAvance2;

public class BaseDeDatos
{
    private readonly SQLiteAsyncConnection _database;

    public BaseDeDatos(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Diario>().Wait();
    }

    public Task<List<Diario>> ObtenerNotasAsync()
    {
        return _database.Table<Diario>().ToListAsync();
    }

    public Task<int> GuardarNotaAsync(Diario diario)
    {
        return diario.Id != 0 ? _database.UpdateAsync(diario) : _database.InsertAsync(diario);
    }

    public Task<int> EliminarNotaAsync(Diario diario)
    {
        return _database.DeleteAsync(diario);
    }
}