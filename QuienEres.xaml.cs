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
        string userName = NameEntry.Text;
       
        Preferences.Set("UserName", userName);


        await Shell.Current.GoToAsync("//inicio");
    }
}
