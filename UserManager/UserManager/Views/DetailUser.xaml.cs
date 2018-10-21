using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserManager.ViewModels;

namespace UserManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailUser : ContentPage
	{
        public User user_detail { get; set; }
        public DetailUser (User user)
		{
			InitializeComponent ();

            BindingContext = new DetailUserVM(user);

        }

        private async void EditBtn_Clicked(object sender, EventArgs e)
        {
            var btn_Eddit = ((Button)sender);
            string _id = btn_Eddit.CommandParameter.ToString();
            await Navigation.PushAsync(new EditUser(_id));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            var btnDelete = ((Button)sender);
            string _id = btnDelete.CommandParameter.ToString();
            bool delete = await DisplayAlert("Delete an user", "Are you sure ??", "Agree", "Cancle");
            if (delete)
            {
                try
                {
                    MessagingCenter.Send(this, "DeleteUser", _id);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            await Navigation.PopAsync();
        }
    }
}