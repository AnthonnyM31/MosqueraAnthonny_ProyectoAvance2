namespace MosqueraAnthonny_ProyectoAvance2;

public partial class VerDiario : ContentPage
{
	public VerDiario()
	{
		InitializeComponent();
	}
   
    public List<DiarioPage.Diario> DiariosList { get; set; }

    private async Task CargarNotas()
    {
        DiariosList = await App.Database.ObtenerNotasAsync();
        BindingContext = null; // Reinicia el contexto para refrescar la UI
        BindingContext = this;
    }

    private async void RecargarActualizaciones_Clicked(object sender, EventArgs e)
    {
        await CargarNotas();
    }
}