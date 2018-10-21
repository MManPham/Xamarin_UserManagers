using System;
using UserManager.Models;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUser : ContentPage
    {
        ListUsersVM viewModel;
        public ListUser()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListUsersVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(viewModel.Items != null)
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
            if(delete)
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

            if(user == null)
            {
                return;
            }
            await Navigation.PushAsync(new DetailUser(user));
        }
    }
}