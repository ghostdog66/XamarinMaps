using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XamarinLatinoMaps.Models;
using XamarinLatinoMaps.Services;

namespace XamarinLatinoMaps.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private List<CoffeeShop> _items;

       

        public List<CoffeeShop> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private CoffeeShop _location;

        public CoffeeShop Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public MainPageViewModel()
        {
            
            Init();
            //GetLocation();
            
            
        }

        private void Init()
        {
           

            Items = new List<CoffeeShop>
            {
                new CoffeeShop
                {
                    Id = 1,
                    Name = "Viva Espresso San Benito",
                    Description = "Centro Comercial Nervión Plaza",
                    Latitude = 37.3914105,
                    Longitude = -5.9591776,
                    Rate = 5
                },

            };

            
            
           
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
        public async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));


            CoffeeShop location2 = new CoffeeShop
            {
                Id = 3,
                Name = "Usted esta aquí",
                Description = "Su localización",
                Latitude = position.Latitude,
                Longitude = position.Longitude,
                Rate = 5
            };

            Items.Add(location2);
            
            
            
        }


    }
}
