using Microsoft.Maui.Controls;
using System;

namespace MiPark
{
    public partial class ParkMC : ContentPage
    {
        private Owner _currentUser;

        public ParkMC(Owner currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            garagesCollectionView.ItemsSource = _currentUser.Parks;
        }

        private async void OnGarageSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedPark = e.CurrentSelection.FirstOrDefault() as Park;
            if (selectedPark != null)
            {
                await DisplayAlert("Garagem Selecionada", $"Você selecionou a garagem em: {selectedPark.Street}, {selectedPark.City}", "OK");
                await Navigation.PushAsync(new ParkInfo(selectedPark));
                
            }
        }
    }
}
