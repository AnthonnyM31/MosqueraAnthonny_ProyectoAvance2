namespace MosqueraAnthonny_ProyectoAvance2;

public partial class DiarioPage : ContentPage
{
    public NotasPage()
    {
        InitializeComponent();
        CargarNotas();
    }

    public List<NuevaNotaPage.Nota> Notas { get; set; }

    private async void CargarNotas()
    {
        Notas = await App.Database.ObtenerNotasAsync();
        BindingContext = null; // Reinicia el contexto para refrescar la UI
        BindingContext = this;
    }

    private async void AgregarNota_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaNotaPage());
    }
}