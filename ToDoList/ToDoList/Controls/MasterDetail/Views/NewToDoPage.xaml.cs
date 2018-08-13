using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoList.ViewModels;

namespace ToDoList.Controls.MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewToDoPage : ContentPage
    {
        public Note Note { get; set; }

        public NewToDoPage()
        {
            InitializeComponent();
            Note = new Note();
            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCommand", Note);
            await Navigation.PopModalAsync();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}