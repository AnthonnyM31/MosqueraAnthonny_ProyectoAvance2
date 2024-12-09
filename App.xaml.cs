namespace MosqueraAnthonny_ProyectoAvance2
{
    public partial class App : Application
    {

        public static BaseDeDatos Database { get; private set; }

        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notas.db3");
            Database = new BaseDeDatos(dbPath);


            if (Preferences.ContainsKey("UserName"))
            {
                MainPage = new AppShell(); // Usa AppShell si ya hay un usuario guardado
            }
            else
            {
                MainPage = new QuienEres(); // Si no, muestra la pantalla inicial
            }
        }
    }


    /*COSAS QUE FALTAN
     -AL PARECER LA PANTALLA DE INICIO FUNCIONA PERO NO ESTOY MUY SEGURO
    -QUIEN ERES, EL ABOUT PAGE EL APP Y EL APPSHELL SON DIFICILES DE ENTENDER, HAY QUE SIMPLIFICARLO
    -*/

}
