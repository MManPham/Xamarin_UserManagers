using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Models;
using UserManager.Views;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class DetailUserVM:BasicViewModel
    {
        private User _user_detail;
        public User user_detail { get => _user_detail; set { _user_detail = value; OnPropertyChanged(); } }
        public DetailUserVM(User user = null)
        {
            Title = user?.Name;
            this.user_detail = user;


            MessagingCenter.Subscribe<DetailUser, string>(this, "DeleteUser", async (obj, _id) =>
            {
                try
                {
                    await DataStore.DeleteItemAsync(_id);

                }
                catch (Exception)
                {

                    throw;
                }

            });

            MessagingCenter.Subscribe<EditUser, User>(this, "EditUserDetailPage", async (obj, user_edit) =>
            {

                await DataStore.UpdateItemAsync(user_edit);

                this.user_detail = user_edit;

            });

        }
    }
}
