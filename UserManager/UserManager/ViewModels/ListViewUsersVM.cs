using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using UserManager.Models;
using UserManager.Views;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class ListUsersVM : BasicViewModel
    {
        private ObservableCollection<User> items;
        public ObservableCollection<User> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("items");
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
                var newItem = item as User;
                Items.Add(item);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<ListUser, string>(this, "DeleteUser", async (obj, _id) =>
            {
                await DataStore.DeleteItemAsync(_id);
                foreach (User user in Items.ToList())
                {
                    if (user.Id == _id)
                    {
                        try
                        {
                            Items.Remove(user);

                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Unsubscribe Error " + e.Message);
                        }
                    }
                }

            });

            MessagingCenter.Subscribe<EditUser, User>(this, "EditUser", async (obj, user_edit) =>
            {

                await DataStore.UpdateItemAsync(user_edit);
                foreach (User user in Items.ToList())
                {
                    if (user.Id == user_edit.Id)
                    {
                        try
                        {
                            Items.CollectionChanged(user_edit)
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Unsubscribe Error " + e.Message);
                        }
                    }
                }
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
