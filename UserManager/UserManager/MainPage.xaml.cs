using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using UserManager.Views;
using UserManager.ViewModels;
using UserManager.Models;

namespace UserManager
{
    public partial class MainPage : ContentPage
    {
        MainPageVM viewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);


        }
        public class TextChangedBehavior : Behavior<SearchBar>
        {
            protected override void OnAttachedTo(SearchBar bindable)
            {
                base.OnAttachedTo(bindable);
                bindable.TextChanged += Bindable_TextChanged;
            }

            protected override void OnDetachingFrom(SearchBar bindable)
            {
                base.OnDetachingFrom(bindable);
                bindable.TextChanged -= Bindable_TextChanged;
            }

            private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
            {
                ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
            }
        }

        async void AddUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUser());
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


        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn_Eddit = ((Button)sender);
            string _id = btn_Eddit.CommandParameter.ToString();

            await Navigation.PushAsync(new EditUser(_id));
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User user = e.SelectedItem as User;

            if (user == null)
            {
                return;
            }
            await Navigation.PushAsync(new DetailUser(user));
        }

        private async void Logout_Clicked_1(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new Login(), this);
            await Navigation.PopAsync();
        }
    }
}
