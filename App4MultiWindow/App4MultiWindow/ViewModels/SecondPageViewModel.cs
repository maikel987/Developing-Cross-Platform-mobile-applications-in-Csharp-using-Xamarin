using App.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App4MultiWindow.ViewModels
{
    public class SecondPageViewModel: INotifyPropertyChanged
    {
        public ICommand PrevCommand { get; set; }
        //private INavigation navigation;
        public string Message { get; set; }
        public Task task { get; set; }
        public ICommand MapLauch { get; set; }

        public SecondPageViewModel()
        {
            PrevCommand = new Command(PrevCommandeAction);
            MapLauch = new Command(mapLauchAction);
            Message = "Loading...";
            LoadGPSData();

        }

        private void mapLauchAction(object obj)
        {
            NavMap();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public async void LoadGPSData()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Message = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Message = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                Message = pEx.Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
        }


        public async void NavMap()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Message = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }

                var location2 = new Location(location.Latitude, location.Longitude);
                var options = new MapsLaunchOptions { Name = "We see you :) " };

                await Maps.OpenAsync(location2, options);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Message = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                Message = pEx.Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));

        }

       

        private void PrevCommandeAction(object obj)
        {
            var nav = AppContainer.Instance.Get<INav>();
            nav.Pop();
        }
    }
}
