namespace MosqueraAnthonny_ProyectoAvance2
{
    public partial class App : Application
    {

        public static BaseDeDatos Database { get; private set; }

        public App()
        {
            InitializeComponent();
            MainPage = new QuienEres();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notas.db3");
            Database = new BaseDeDatos(dbPath);

        }
    }

}
