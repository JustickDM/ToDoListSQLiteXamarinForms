using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Controls.MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (enLogin.Text != null && enPassword.Text != null)
            {
                CrossSettings.Current.AddOrUpdateValue("Login", enLogin.Text);
                CrossSettings.Current.AddOrUpdateValue("Password", enPassword.Text);
                await Navigation.PopModalAsync();
            }
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<INativeHelper>().CloseApp();
        }
    }
}