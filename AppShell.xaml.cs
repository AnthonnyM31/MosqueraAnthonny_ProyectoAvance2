namespace MosqueraAnthonny_ProyectoAvance2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            // Registrar rutas para la navegación
            Routing.RegisterRoute("inicio", typeof(InicioPage));
            Routing.RegisterRoute("about", typeof(AboutPage));
            Routing.RegisterRoute("diario", typeof(DiarioPage));
            Routing.RegisterRoute("verdiario", typeof(VerDiario));
        }
    }
}
