using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TShirtKings
{
    public class Items:ContentsPage
    {
        public Items()
        {
             Title = "Todo Item";

               var nameEntry = new Entry();
               nameEntry.SetBinding(Entry.TextProperty, "Name");

               var genderEntry = new Entry();
               genderEntry.SetBinding(Entry.TextProperty, "Gender");

               var shirtSizeEntry = new Entry();
               shirtSizeEntry.SetBinding(Entry.TextProperty, "ShirtSize");

               var dateOfOrderEntry = new Entry();
               dateOfOrderEntry.SetBinding(Entry.TextProperty, "DateOfOrder");

               var ShirtNameEntry = new Entry();
               ShirtNameEntry.SetBinding(Entry.TextProperty, "ShirtName");

               var shippingAddressEntry = new Entry();
               shippingAddressEntry.SetBinding(Entry.TextProperty, "ShippingAddress");
                

               var emailAddressEntry = new Entry();
               emailAddressEntry.SetBinding(Entry.TextProperty, "EmailAddress");

               var contactDetailsEntry = new Entry();
               contactDetailsEntry.SetBinding(Entry.TextProperty, "ContactDetails");

               var doneSwitch = new Switch();
               doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

                var saveButton = new Button { Text = "Save" };
                saveButton.Clicked += async (sender, e) =>
                {
                    var TShirtTable = (TShirtTable)BindingContext;
                    await App.Database.SaveItemAsync(TShirtTable);
                    await Navigation.PopAsync();
                };

               var deleteButton = new Button { Text = "Delete" };
               deleteButton.Clicked += async (sender, e) =>
               {
                   var TShirtTable = (TShirtTable)BindingContext;
                   await App.Database.DeleteItemAsync(TShirtTable);
                   await Navigation.PopAsync();
               };

               Content = new StackLayout
               {
                   Margin = new Thickness(20),
                   VerticalOptions = LayoutOptions.StartAndExpand,
                   Children =
                   {
                       new Label { Text = "Name" },
                       nameEntry,
                       new Label { Text = "Gender" },
                       genderEntry,
                       new Label { Text = "ShirtSize" },
                       shirtSizeEntry,
                       new Label { Text = "DateOfOrder" },
                       dateOfOrderEntry,
                       new Label { Text = "ShirtName" },
                       ShirtNameEntry,
                       new Label { Text = "ShippingAddress" },
                       shippingAddressEntry,
                       new Label { Text = "EmailAddress" },
                       emailAddressEntry,
                       new Label { Text = "ContactDetails" },
                       contactDetailsEntry,


                       new Label { Text = "Done" },
                       doneSwitch,

                       saveButton,
                       
                       
                       
                   }
               };

        }

    }
}
