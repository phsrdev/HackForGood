namespace MiPark;

public partial class ClientAreaPage : ContentPage
{
    private string _username;
    private string _userId;

    public ClientAreaPage(string username, string userId)
    {
        InitializeComponent();
        _username = username;
        _userId = userId;
        WelcomeMessage.Text = $"¡Bienvenido a la Área del Cliente de MiPark, {_username}!";
    }


    private async void OnRegisterVehicleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterVehiclePage(_userId));
    }

    private async void OnSearchGaragesClicked(object sender, EventArgs e)
    {
        // Navega para a página de busca de garagens
        // Substitua "MapPage" pelo nome real da sua página de mapa
        await Navigation.PushAsync(new MapPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Implemente sua lógica de deslogar aqui
        // Por exemplo, voltar para a página de login
        await Navigation.PopToRootAsync();
    }
}