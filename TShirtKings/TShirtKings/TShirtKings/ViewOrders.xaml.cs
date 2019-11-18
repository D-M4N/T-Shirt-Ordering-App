using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtKings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewOrders : ContentPage
    {
        public List<TShirtTable> TShirtOrders { get; set; }
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