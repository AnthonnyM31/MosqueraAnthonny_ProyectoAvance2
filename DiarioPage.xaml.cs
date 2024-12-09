using SQLite;

namespace MosqueraAnthonny_ProyectoAvance2;

public partial class DiarioPage : ContentPage
{
    public DiarioPage()
    {
        InitializeComponent();
        CargarNotas();
    }

    public List<DiarioPage.Diario> DiariosList { get; set; }



    public class Diario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //si no están marcadas como opcionales o requeridas no se por que pero no funciona asi que vamos a permitir valores null
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;

        public static int TotalActualizaciones { get; set; } = 0;
        public static int Puntos { get; set; } = 0;
    }


  
  

    public class Configuracion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TotalActualizaciones { get; set; }
        public int Puntos { get; set; }
    }




    private async void CargarNotas()
    {
        DiariosList = await App.Database.ObtenerNotasAsync();
        BindingContext = null; // Reinicia el contexto para refrescar la UI
        BindingContext = this;
    }

    private async void AgregarNota_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AcutalizacionesDiario());
    }
}