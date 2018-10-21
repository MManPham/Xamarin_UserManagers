using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Models;

namespace UserManager.ViewModels
{
    public class EditUserVM:BasicViewModel
    {
        public User user_edit { get; set; }

        public EditUserVM(string _id)
        {

            this.GetUser(_id);

            Title = this.user_edit.Name;
            
        }

        public async void GetUser(string _id)
        {
            try
            {
               this.user_edit = await DataStore.GetItemAsync(_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    
}
