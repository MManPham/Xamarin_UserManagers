using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using UserManager.Models;
using UserManager.Views;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class MainPageVM : BasicViewModel
    {
        private ObservableCollection<User> _item;
        public ObservableCollection<User> Items
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }


        public Command LoadItemsCommand { get; set; }


        public MainPageVM()
        {
            Title = "List User";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            Items = new ObservableCollection<User>();



            MessagingCenter.Subscribe<AddUser, User>(this, "AddItem", async (obj, item) =>
            {

                await DataStore.AddUserAsync(item);
                LoadItemsCommand.Execute(null);

            });

            MessagingCenter.Subscribe<MainPage, string>(this, "DeleteUser", async (obj, _id) =>
            {
                await DataStore.DeleteUserAsync(_id);

                LoadItemsCommand.Execute(null);

            });

            MessagingCenter.Subscribe<EditUser, User>(this, "EditUser", async (obj, user_edit) =>
            {
                await DataStore.UpdateUserAsync(user_edit);
                LoadItemsCommand.Execute(null);

            });

        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var ListItems = await DataStore.GetUsersAsync(true);
                foreach (var item in ListItems)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
