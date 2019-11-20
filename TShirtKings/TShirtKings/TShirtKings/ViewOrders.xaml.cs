using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtKings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewOrders : ContentPage
    {
        public List<TShirtTable> TShirtOrders { get; set; }

        private TShirtTable Orders;
        public ViewOrders()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var tshirtDatabase = App.Database;
            TShirtOrders = await tshirtDatabase.GetItemsAsync();
            BindingContext = this;
        }

        private async void OnConfirmOrderClicked(object sender, EventArgs e)
        {
            var client = new HttpClient(new HttpClientHandler());
            var url = "https://10.0.2.2:5001/TshirtOrder";
            var TShirttable = new TShirtTable();
            var json = JsonConvert.SerializeObject(TShirttable);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Exceptions", "Try Again", "ok");
            }
        }


        private async void Adress_Button(object sender, EventArgs e)
        


           // public async Task NavigateToBuilding25()
            {
                var placemark = new Placemark
                {
                    CountryName = "South Africa",
                    AdminArea = "MP",
                    Thoroughfare = "The Cedars Avenue 28",
                    Locality = "Rocklands"
                };
                var options = new MapLaunchOptions { Name = "The Cedars Avenue 28" };

                await Map.OpenAsync(placemark, options);
            }

        private async void OnTRACKPackageClicked(object sender, EventArgs e)
        {
            if (Orders != null)
            {
                var placemark = new Placemark
                {
                    Thoroughfare = Orders.ShippingAddress
                };
                var options = new MapLaunchOptions { Name = Orders.Name };
                await Map.OpenAsync(placemark, options);
            }
        }

        private void SelectedTShirtOrder(object sender, SelectedItemChangedEventArgs e)
        {
            Orders = e.SelectedItem as TShirtTable;
        }


        /* var client = new HttpClient();

         var url = "https://10.0.2.2:5001/TshirtOrder";

         var content = new StringContent("{\"name\":\"bob\", \"price\":300}");

         var response = await client.PostAsync(url, content);


             var tShirttable = (TShirtTable)BindingContext;
             await App.Database.SaveItemAsync(tShirttable);


             var url = "http://10.0.2.2:5000/TshirtOrder";
             var client = new HttpClient();
             var Product = new
             {
                 Name = "D-M4N",

                 Gender = "MaN",

                 ShirtSize = "XXL",

                 DateOfOrder = "Today",

                 ShirtName = "CRYTEK",

                 ShippingAddress = "MY HOOD",

                 EmailAddress = "Just@work.com",

                 ContactDetails = "021187911"
             };

             var json = JsonConvert.SerializeObject(Product);
             var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
             try
             {
                 var response = await client.PostAsync(url, content);
                 //await DisplayAlert("Response Message", response.ReasonPhrase);
             }
             catch (Exception ex)
             {
                 await DisplayAlert("Exception", ex.Message, "Ok");
             }
         */


    }
}