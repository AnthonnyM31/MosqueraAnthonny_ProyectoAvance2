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
        _database.CreateTableAsync<Configuracion>().Wait();
    }



    //solo para el sistema de puntos

    public async Task<Configuracion> ObtenerConfiguracionAsync()
    {
        var config = await _database.Table<Configuracion>().FirstOrDefaultAsync();
        if (config == null)
        {
            config = new Configuracion { TotalActualizaciones = 0, Puntos = 0 };
            await _database.InsertAsync(config);
        }
        return config;
    }

    // se actualizazn los puntos
    public Task<int> GuardarConfiguracionAsync(Configuracion config)
    {
        return _database.UpdateAsync(config);
    }

    //----------------------------------------------------------------------------------------------


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