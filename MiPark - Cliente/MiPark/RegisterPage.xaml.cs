using BCrypt.Net;
using System;
using System.Text.RegularExpressions;

namespace MiPark
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            var dni = dniEntry.Text;
            string username = usernameEntry.Text;
            string surname = surnameEntry.Text;
            var password = passwordEntry.Text;
            var confirmPassword = confirmPasswordEntry.Text;
            var phoneNumber = phoneNumberEntry.Text;



            //if (Methods.IsEmailExists(email)) 
            //{
            //    await DisplayAlert("Error", "Email ya existe", "OK");
            //    return
            //}

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(dni))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }


            var formatPhoneNumber = new Regex(@"^\+34\s\d{9}$");
            var formatDNI = new Regex(@"(\d{8})([A-Za-z])");

            if (phoneNumber != null && !formatPhoneNumber.IsMatch(phoneNumber))
            {
                await DisplayAlert("Error", "Formato del Telefono no esta correcto, ejemplo (+34 123123123)", "OK");
                return;
            }


            if (!formatDNI.IsMatch(dni))
            {
                await DisplayAlert("Error", "Formato del DNI no esta correcto, ejemplo (12345678F)", "OK");
                return;
            }
            
            dni = formatDNI.Replace(dni, m => m.Groups[1].Value + m.Groups[2].Value.ToUpper());

            //if (Methods.IsDNIUnqiue(dni))
            //{
            //    await DisplayAlert("Error", "DNI ya existe", "OK");
            //   return;
            //
            //}



            // Encrypts password and saves it on DataBase
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            // Saves on DataBase
            //string userID = DataStorage.PasswordManager(email, username, surname, hashedPassword, phoneNumber, dni);

            // Go to user's homepage
            await Navigation.PushAsync(new ClientAreaPage(username, "userID"));
        }

        private async void OnVolverButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

