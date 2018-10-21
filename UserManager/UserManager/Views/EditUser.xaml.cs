using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditUser : ContentPage
	{
        public EditUserVM EditViewModel { get; set; }
        public EditUser (string _id)
		{
			InitializeComponent ();

            BindingContext = EditViewModel = new EditUserVM(_id);

           

        }



        private async void edit_submit_Clicked(object sender, EventArgs e)
        {
            User user_edit = EditViewModel.user_edit;

            try
            {
                MessagingCenter.Send(this, "EditUser", user_edit);
            }
            catch (Exception)
            {

                await DisplayAlert("Require", "Some feild is requid!!", "Cancle");
            }

            await Navigation.PopAsync();

        }
    }
}