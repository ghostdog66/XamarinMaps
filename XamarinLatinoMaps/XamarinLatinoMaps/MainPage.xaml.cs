using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinLatinoMaps.Framework.Renderers;
using XamarinLatinoMaps.ViewModels;

namespace XamarinLatinoMaps
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                MapView.MoveToRegion(new MapSpan(MapView.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            
            var pin = new CustomPin 
            {
                Type = PinType.Place,
                Position = new Position(37.287669, -5.928164),
                Label = "Dos hermanas",
                Address = "394 Pacific Ave, San Francisco CA",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            MapView.Pins.Add(pin);
        }

	    private void Street_OnClicked(object sender, EventArgs e)
	    {
	        MapView.MapType = MapType.Street;
	    }


	    private void Hybrid_OnClicked(object sender, EventArgs e)
	    {
	        MapView.MapType = MapType.Hybrid;
	    }

	    private void Satellite_OnClicked(object sender, EventArgs e)
	    {
	        MapView.MapType = MapType.Satellite;
	    }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy=50;

            var position1 = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            LogitudeLabel.Text = position1.Longitude.ToString();

            LatitudeLabel.Text = position1.Latitude.ToString();

            MapView.MoveToRegion(
               MapSpan.FromCenterAndRadius(
                   new Position(position1.Latitude, position1.Longitude), Distance.FromKilometers(0.5)));

            var pin = new CustomPin()
            {
                Position = new Position(position1.Latitude, position1.Longitude),
                Label = "Hola amigos",
                Address = "Hola amigos 2",
                Type = PinType.SavedPin,
                Url = "http://xamarin.com/about/"

            };
            MapView.Pins.Add(pin);

            
            
        }
      




    }
}
