using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using UserManager.Models;
using UserManager.Views;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class ListUsersVM : BasicViewModel
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


        public ListUsersVM()
        {
            Title = "List User";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            Items = new ObservableCollection<User>();



            MessagingCenter.Subscribe<AddUser, User>(this, "AddItem", async (obj, item) =>
            {

                await DataStore.AddItemAsync(item);
                LoadItemsCommand.Execute(null);

            });

            MessagingCenter.Subscribe<ListUser, string>(this, "DeleteUser", async (obj, _id) =>
            {
                await DataStore.DeleteItemAsync(_id);
                LoadItemsCommand.Execute(null);

            });

            MessagingCenter.Subscribe<EditUser, User>(this, "EditUser", async (obj, user_edit) =>
            {
                await DataStore.UpdateItemAsync(user_edit);
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
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
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
