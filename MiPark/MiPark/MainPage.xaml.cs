using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using Microsoft.Maui.Storage;

namespace MiPark
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeThemePreference();
            LoadSavedCredentials();
        }

        private void InitializeThemePreference()
        {
            var themePreference = Preferences.Get("UserThemePreference", string.Empty);
            if (!string.IsNullOrEmpty(themePreference))
            {
                var theme = (AppTheme)Enum.Parse(typeof(AppTheme), themePreference);
                Application.Current.UserAppTheme = theme;

                themeToggleCheckBox.IsChecked = theme == AppTheme.Light;
            }
        }

        private void OnThemeToggleCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var newTheme = e.Value ? AppTheme.Light : AppTheme.Dark;
            Application.Current.UserAppTheme = newTheme;

            Preferences.Set("UserThemePreference", newTheme.ToString());

        }

        private void LoadSavedCredentials()
        {
            var username = Preferences.Get("Username", string.Empty);
            var password = Preferences.Get("Password", string.Empty);
            var saveCredentials = Preferences.Get("SaveCredentials", false);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && saveCredentials)
            {
                usernameEntry.Text = username;
                passwordEntry.Text = password;
                saveCredentialsCheckBox.IsChecked = true;
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;

            var filePath = Path.Combine(FileSystem.AppDataDirectory, "owners.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var owners = JsonConvert.DeserializeObject<List<Owner>>(json);

                var owner = owners.FirstOrDefault(o => o.Email == username && o.Password == password);

                if (owner != null)
                {
                    if (saveCredentialsCheckBox.IsChecked)
                    {
                        // Salvar as credenciais apenas se o CheckBox estiver marcado
                        Preferences.Set("Username", username);
                        Preferences.Set("Password", password);
                        Preferences.Set("SaveCredentials", true); // Guarda a preferência do usuário para salvar credenciais
                    }
                    else
                    {
                        // Remover as credenciais salvas se o CheckBox não estiver marcado
                        Preferences.Remove("Username");
                        Preferences.Remove("Password");
                        Preferences.Set("SaveCredentials", false);
                    }

                    await DisplayAlert("Login", "Login bem-sucedido!", "OK");
                    await Navigation.PushAsync(new DashboardPage(owner));
                }
                else
                {
                    await DisplayAlert("Erro", "Credenciais inválidas.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Nenhum usuário registrado encontrado.", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OwnerRegister());
        }

        private async void OnViewRegisteredUsersClicked(object sender, EventArgs e)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "owners.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var owners = JsonConvert.DeserializeObject<List<Owner>>(json);

                // Acessando a propriedade Password diretamente.
                var usersInfo = owners.Select(o => $"Email: {o.Email}, Senha: {o.Password}").ToList();

                await DisplayAlert("Usuários Registrados", string.Join("\n", usersInfo), "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Nenhum usuário registrado encontrado.", "OK");
            }
        }
    }
}
