using Microsoft.Maui.Storage;

namespace MosqueraAnthonny_ProyectoAvance2;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtener el nombre del usuario desde Preferences
        string userName = Preferences.Get("UserName", "Usuario");

        // Mostrar el nombre del usuario
        NombreUsuarioLabel.Text = $"Bienvenido, {userName}";

        // Obtener configuraciones (actualizaciones y puntos)
        var configuracion = await App.Database.ObtenerConfiguracionAsync();
        ActualizacionesLabel.Text = $"Actualizaciones realizadas: {configuracion.TotalActualizaciones}";
        PuntosLabel.Text = $"Puntos acumulados: {configuracion.Puntos}";
    }
}
