using System;
using Xamarin.Forms;
using ToDoList;
using ToDoList.Controls.MasterDetail.Views;
using ToDoList.Controls.MasterDetail.Items;
using ToDoList.ViewModels;
using Plugin.Settings;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controls.MasterDetail.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private User user { get; set; }

        public MainPage()
        {
            InitializeComponent();
            user = new User();
            masterPage.listView.ItemSelected += OnItemSelected;
        }

        protected override async void OnAppearing()
        {
            user.Login = CrossSettings.Current.GetValueOrDefault("Login", "Null");
            user.Password = CrossSettings.Current.GetValueOrDefault("Password", "Null");
            if(user.Login == "Null" && user.Password == "Null")
            {
                await Navigation.PushModalAsync(new LoginPage());
            }
            base.OnAppearing();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                if (item.Title != "Logout")
                {
                    await (this?.Detail as NavigationPage)?.PushAsync(page);
                }else
                {
                    CrossSettings.Current.Remove("Login");
                    CrossSettings.Current.Remove("Password");
                    await Detail.Navigation.PushModalAsync(page);
                }
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
