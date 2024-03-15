using Microsoft.Maui.Controls;
using System;

namespace MiPark
{
    public partial class ParkRegister : ContentPage
    {
        private Owner _currentOwner;

        public ParkRegister(Owner currentOwner)
        {
            InitializeComponent();
            _currentOwner = currentOwner;

            // Defina o país como "España" por padrão e desative a edição inicialmente
            countryEntry.Text = "España";
            countryEntry.IsEnabled = false;
        }
        private void OnCountryCheckboxChanged(object sender, CheckedChangedEventArgs e)
        {
            // Permita a edição do campo País se o CheckBox estiver marcado
            countryEntry.IsEnabled = e.Value;
        }

        private async void OnRegisterGarageClicked(object sender, EventArgs e)
        {
            // Cria uma nova instância de Park com os dados do formulário
            var park = new Park
            {
                Street = streetEntry.Text,
                Number = numberEntry.Text,
                AdditionalInfo = additionalInfoEntry.Text,
                City = cityEntry.Text,
                Province = provinceEntry.Text,
                ZIPCODE = zipCodeEntry.Text,
                Country = countryEntry.Text
            };

            _currentOwner.AddPark(park);

            await DataStorage.SaveOwnerDataAsync(_currentOwner);

            await DisplayAlert("Registro", "Garagem registrada com sucesso.", "OK");
            await Navigation.PushAsync(new DashboardPage(_currentOwner));
        }
    }
}