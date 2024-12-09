using SQLite;
using static MosqueraAnthonny_ProyectoAvance2.DiarioPage;
namespace MosqueraAnthonny_ProyectoAvance2;

public partial class AcutalizacionesDiario : ContentPage
{
	public AcutalizacionesDiario()
	{
		InitializeComponent();
	}








    private async void GuardarNota_Clicked(object sender, EventArgs e)
    {
        string titulo = TituloNota.Text;
        string contenido = ContenidoNota.Text;

        if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(contenido))
        {
            var nuevoDiario = new Diario
            {
                Titulo = titulo,
                Contenido = contenido,
                FechaHora = DateTime.Now
            };

            await App.Database.GuardarNotaAsync(nuevoDiario);

            // Incrementar actualizaciones y calcular puntos
            var config = await App.Database.ObtenerConfiguracionAsync();
            config.TotalActualizaciones++;

            if (config.TotalActualizaciones % 5 == 0)
            {
                config.Puntos += 100;
                await DisplayAlert("¡Felicidades!", "Has ganado 100 puntos.", "OK");
            }

            await App.Database.GuardarConfiguracionAsync(config);

            await DisplayAlert("Actualización Guardada", "Tu diario ha sido actualizado con éxito.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
        }
    }


}