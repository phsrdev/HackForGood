namespace MiPark;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
        LoadMap();
    }

    private void LoadMap()
    {
        // Coordenadas do centro de Madrid
        double defaultLatitude = 40.416775;
        double defaultLongitude = -3.703790;

        var htmlSource = new HtmlWebViewSource
        {
            Html = $@"
                <html>
                <head>
                    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.7.1/dist/leaflet.css' />
                    <script src='https://unpkg.com/leaflet@1.7.1/dist/leaflet.js'></script>
                    <style>
                        #map {{ height: 100%; }}
                    </style>
                </head>
                <body>
                    <div id='map'></div>
                    <script>
                        var map = L.map('map').setView([{defaultLatitude}, {defaultLongitude}], 13);
                        L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{
                            attribution: '&copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a> contributors'
                        }}).addTo(map);
                    </script>
                </body>
                </html>"
        };
        webView.Source = htmlSource;
    }

    private async void OnSearchNearMeClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                await webView.EvaluateJavaScriptAsync($@"
                    map.setView([{location.Latitude}, {location.Longitude}], 13);
                ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível obter a localização: {ex.Message}");
        }
    }

    private void OnSearchByAddressClicked(object sender, EventArgs e)
    {
        // Implemente a lógica para buscar por endereço
    }

    private void OnReserveGarageClicked(object sender, EventArgs e)
    {
        // Implemente a lógica para reservar uma garagem
    }
}