namespace MosqueraAnthonny_ProyectoAvance2;

public partial class VerDiario : ContentPage
{
	public VerDiario()
	{
		InitializeComponent();
	}
    public List<NuevaNotaPage.Nota> Notas { get; set; }

    private async Task CargarNotas()
    {
        Notas = await App.Database.ObtenerNotasAsync();
        BindingContext = null; // Reinicia el contexto para refrescar la UI
        BindingContext = this;
    }

    private async void RecargarNotas_Clicked(object sender, EventArgs e)
    {
        await CargarNotas();
    }
}