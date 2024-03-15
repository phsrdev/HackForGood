using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MiPark;

public partial class OwnerInfoPage : ContentPage
{
    private Owner _currentOwner;

    public OwnerInfoPage(Owner currentOwner)
    {
        InitializeComponent();
        _currentOwner = currentOwner;
        LoadOwnerInfo();
    }

    private void LoadOwnerInfo()
    {
        nameLabel.Text = $"Nome: {_currentOwner.Name} {_currentOwner.Surname}";
        emailLabel.Text = $"Email: {_currentOwner.Email}";
        ibanLabel.Text = $"IBAN: {_currentOwner.Iban}";

        garagesCollectionView.ItemsSource = new ObservableCollection<Park>(_currentOwner.Parks);
    }
}
