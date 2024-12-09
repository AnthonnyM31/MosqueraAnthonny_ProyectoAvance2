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

            await DisplayAlert("Nota Guardada", "Tu nota ha sido guardada con éxito.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
        }
    }

}