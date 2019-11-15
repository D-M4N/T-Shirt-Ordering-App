using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;


namespace TShirtKings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();

        }


          

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tShirttable = new TShirtTable();

            BindingContext = tShirttable;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
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
               // await DisplayAlert("Response Message", response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "Ok");
            }



            /*
             *var client = new HttpClient();

              var url = "https://10.0.2.2:5001/TshirtOrder";

              var content = new StringContent("{\"name\":\"bob\", \"price\":300}");

              var response = await client.PostAsync(url, content);
              */






        }

    /*
     
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var tShirttable = (TShirtTable)BindingContext;

            await App.Database.SaveItemAsync(tShirttable);
            await Navigation.PopAsync();

        }


    */


        private void OnDeleteClicked(object sender, EventArgs e)
        {

        }



        private void Cancel_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentsPage());
        }


    }
}