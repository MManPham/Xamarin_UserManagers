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
            string name = nameUser.Text;
            bool checkAgeNumb = int.TryParse(ageUser.Text, out int age);
            string addr = address.Text;
            this.newUser = new User
            {
                Name = name,
                Age = int.Parse(ageUser.Text),
                Address = address.Text,
                Phone = phone.Text,
                Position = position.Text,
                Salary = int.Parse(salary.Text)
            };
            try
            {
                MessagingCenter.Send(this, "AddItem", this.newUser);
            }
            catch (Exception )
            {

                await DisplayAlert("Require", "Some feild is requid!!", "Cancle");
            }
               
            await Navigation.PopAsync();

        }


    }
}