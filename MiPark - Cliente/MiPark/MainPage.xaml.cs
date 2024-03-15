using System;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;


namespace MiPark;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadSavedCredentials();
    }

    private void OnThemeToggleCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var newTheme = e.Value ? AppTheme.Light : AppTheme.Dark;
        Application.Current.UserAppTheme = newTheme;

        Preferences.Set("UserThemePreference", newTheme.ToString());

    }


    private void LoadSavedCredentials()
    {
        // NOTA PESSOAL: Revisar a abordagem de armazenamento das credenciais para a versão oficial.
        var saveCredentials = Preferences.Get("SaveCredentials", false);
        saveCredentialsCheckBox.IsChecked = saveCredentials;

        if (saveCredentials)
        {
            var email = Preferences.Get("Email", string.Empty);
            var password = Preferences.Get("Password", string.Empty);

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                loginEmailEntry.Text = email;
                loginPasswordEntry.Text = password;
            }
        }
    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var isConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
        Console.WriteLine($"Conectado na internet: {isConnected}"); // NOTA: Considerar feedback visual para o usuário na versão final.

        var email = loginEmailEntry.Text;
        var password = loginPasswordEntry.Text;

        if (isConnected)
        {
            // NOTA: Implementar mecanismo de autenticação real na versão final.
            //bool isLoginSuccessful = username == "admin" && password == "1234"; // LEMBRETE: Isso é apenas para teste. Implementar autenticação segura.

            //bool isLoginSuccessful = Methods.AuthenticateUser(email, password);

            // Email: adm@gmail.com       password: adm
            bool isLoginSuccessful = Methods.AuthenticateDebug(email, password);

            if (isLoginSuccessful)
            {
                // Atualizar o estado do CheckBox nas preferências
                Preferences.Set("SaveCredentials", saveCredentialsCheckBox.IsChecked);

                if (saveCredentialsCheckBox.IsChecked)
                {
                    Preferences.Set("Email", email);
                    Preferences.Set("Password", password);
                }
                else
                {
                    // Se o usuário desmarcar o CheckBox, remover as credenciais salvas
                    Preferences.Remove("Email");
                    Preferences.Remove("Password");
                }

                //string userId = Methods.GetUserId(email);
                //string username = Methods.GetUserName(email);
                //await Navigation.PushAsync(new ClientAreaPage(username, userId));
                await Navigation.PushAsync(new ClientAreaPage(email, password));

            }
            else
            {
                await DisplayAlert("Error", "Inicio de sesión fallido. Por favor, verifique sus credenciais.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "No hay conexión a internet.", "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private void OnGoogleLoginClicked(object sender, EventArgs e)
    {
        // Implementação futura
    }

    private void OnAppleLoginClicked(object sender, EventArgs e)
    {
        // Implementação futura
    }
}