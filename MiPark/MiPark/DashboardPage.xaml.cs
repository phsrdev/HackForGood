namespace MiPark;

public partial class DashboardPage : ContentPage
{
    private Owner _currentUser;

    public DashboardPage(Owner currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;

        // Atualize a UI com base no usuário, se necessário
        UpdateUIBasedOnCurrentUser();
    }

    private void UpdateUIBasedOnCurrentUser()
    {
        // Exemplo: Atualizar a mensagem de boas-vindas para incluir o nome do usuário
        welcomeLabel.Text = $"Bem-vindo, {_currentUser.Name}!";
    }

    private async void OnRegisterGarageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ParkRegister(_currentUser));
    }

    private async void OnPersonalInfoClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OwnerInfoPage(_currentUser));
    }

    private async void OnManageGarageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ParkMC(_currentUser));
    }
}
