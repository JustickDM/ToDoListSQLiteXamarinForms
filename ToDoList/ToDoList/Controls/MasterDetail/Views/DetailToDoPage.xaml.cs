using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Controls.MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailToDoPage : ContentPage
	{
        public Note Note { get; set; }

        public DetailToDoPage (Note note)
		{
			InitializeComponent ();
            Note = note;
            BindingContext = this;
		}

        private async void Update_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirm action", "Do you want to update the entry?", "Yes", "No");
            if(result)
            {
                MessagingCenter.Send(this, "UpdateCommand", Note);
                await Navigation.PopModalAsync();
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}