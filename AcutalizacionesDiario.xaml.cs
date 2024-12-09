using SQLite;

namespace MosqueraAnthonny_ProyectoAvance2;

public partial class AcutalizacionesDiario : ContentPage
{
	public AcutalizacionesDiario()
	{
		InitializeComponent();
	}
    public class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //si no están marcadas como opcionales o requeridas no se por que pero no funciona asi que vamos a permitir valores null
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
    }











    private async void GuardarNota_Clicked(object sender, EventArgs e)
    {
        string titulo = TituloNota.Text;
        string contenido = ContenidoNota.Text;

        if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(contenido))
        {
            var nuevaNota = new Nota
            {
                Titulo = titulo,
                Contenido = contenido,
                FechaHora = DateTime.Now
            };

            await App.Database.GuardarNotaAsync(nuevaNota);

            await DisplayAlert("Nota Guardada", "Tu nota ha sido guardada con éxito.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
        }
    }

}