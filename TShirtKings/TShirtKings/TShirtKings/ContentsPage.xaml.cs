using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtKings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsPage : ContentPage
    {
        public ContentsPage()
        {
            InitializeComponent();
        }

        private void OrderButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
    }
}