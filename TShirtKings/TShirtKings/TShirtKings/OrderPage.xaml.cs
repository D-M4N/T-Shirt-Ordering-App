using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            var tShirttable = (TShirtTable)BindingContext;

            await App.Database.SaveItemAsync(tShirttable);
            await Navigation.PopAsync();

        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {

        }



        private void Cancel_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentsPage());
        }


    }
}