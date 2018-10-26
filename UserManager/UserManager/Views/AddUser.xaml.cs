using System;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        public User newUser { get; set; }
        public AddUser()
        {
            InitializeComponent();

        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            string _name = nameUser.Text;
            bool isNum = int.TryParse(Convert.ToString(ageUser.Text), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,  out int _age);
            string _addr = address.Text;
            string _phone = phone.Text;

            if(_name == null || _addr == null ||_addr== null || _phone== null)
            {
                await DisplayAlert("Warning", "There is a least one field is being empty", "Cancle");
            }
            else if(isNum == false)
            {
                await DisplayAlert("Warning", "Age required type number", "Cancle");
            }
            else
            {
                this.newUser = new User
                {
                    Name = _name,
                    Age = _age,
                    Address = _addr,
                    Phone = _phone,
                };
                try
                {
                    MessagingCenter.Send(this, "AddItem", this.newUser);
                }
                catch(Exception) { throw; }

                await Navigation.PopAsync();
            }



        }
        private async void Logout_Clicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new Login(), this);
            await Navigation.PopAsync();
        }

    }
}