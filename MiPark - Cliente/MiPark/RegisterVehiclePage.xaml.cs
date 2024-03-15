using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;

namespace MiPark
{
    public partial class RegisterVehiclePage : ContentPage
    {
        private string _Id;

        public RegisterVehiclePage(string userId)
        {
            InitializeComponent();
            LoadBrandsIntoPicker();
            LoadColorsIntoPicker();
            _Id = userId;
        }


        private void LoadBrandsIntoPicker()
        {
            foreach (var brand in CarData.BrandsAndModels.Keys)
            {
                brandPicker.Items.Add(brand);
            }
        }

        private void LoadColorsIntoPicker()
        {
            foreach (var color in CarData.VehicleColors)
            {
                colorPicker.Items.Add(color);
            }
        }

        private void BrandPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelPicker.Items.Clear();
            var selectedBrand = brandPicker.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedBrand) && CarData.BrandsAndModels.ContainsKey(selectedBrand))
            {
                foreach (var model in CarData.BrandsAndModels[selectedBrand])
                {
                    modelPicker.Items.Add(model);
                }

                modelPicker.IsEnabled = true;
            }
        }

        private async void RegisterVehicle_Clicked(object sender, EventArgs e)
        {
            var matriculaInput = matriculaEntry.Text;
            var selectedBrand = brandPicker.SelectedItem as string;
            var selectedModel = modelPicker.SelectedItem as string;
            var selectedColor = colorPicker.SelectedItem as string;

            // Ajusta a expressão regular para permitir letras maiúsculas ou minúsculas e com ou sem espaço.
            var regexMatricula = new Regex("^[0-9]{4}\\s?[A-Za-z]{3}$");

            if (!regexMatricula.IsMatch(matriculaInput))
            {
                await DisplayAlert("Error", "La matrícula no está en el formato correcto (ejemplo: 1234 ABC).", "OK");
                return;
            }

            if (string.IsNullOrEmpty(matriculaInput) || string.IsNullOrEmpty(selectedBrand) || string.IsNullOrEmpty(selectedModel) || string.IsNullOrEmpty(selectedColor))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Normaliza a matrícula para o formato desejado: 4 dígitos, espaço, 3 letras maiúsculas
            var matriculaNormalized = matriculaInput.ToUpper();
            if (!matriculaNormalized.Contains(" "))
            {
                // Insere um espaço entre os 4 dígitos e as 3 letras se necessário
                matriculaNormalized = matriculaNormalized.Insert(4, " ");
            }

            // Add Car
            var car = new Car()
            {
                Plate = matriculaNormalized,
                Brand = selectedBrand,
                Model = selectedModel,
                Color = selectedColor,
                //Year  = No year for now
            };

            //var user = DataStorage.getUser(_Id);

            var userCar = new UserCar()
            {
                UserID = _Id,
                Plate = matriculaNormalized,
            };



            if (Methods.IsUserAndCarRegistered(_Id, car.Plate)) { await DisplayAlert("Error", "Coche ya matriculado en tu nombre.", "OK"); return; }


            DataStorage.RegisterCar(car);
            DataStorage.RegisterUserCar(userCar);

            await DisplayAlert("Éxito", $"Vehículo registrado: {matriculaNormalized}, {selectedBrand} {selectedModel}, {selectedColor}", "OK");
        }

        private async void OnVolverButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}