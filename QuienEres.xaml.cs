using Microsoft.Maui.Controls;
namespace MosqueraAnthonny_ProyectoAvance2;

public partial class QuienEres : ContentPage
{
	public QuienEres()
    {
        InitializeComponent();
    }

    private async void OnStartButtonClicked(object sender, EventArgs e)
    {
        // Verifica si NameEntry no es null y tiene texto
        if (NameEntry == null || string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, escribe tu nombre antes de continuar.", "OK");
            return;
        }

        string userName = NameEntry.Text;

        // Guarda el nombre en las preferencias
        Preferences.Set("UserName", userName);

        // Navega a la página principal
        await Shell.Current.GoToAsync("//InicioPage");
    }

}
