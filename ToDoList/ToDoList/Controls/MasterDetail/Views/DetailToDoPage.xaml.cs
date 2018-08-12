using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoList.Interfaces;

namespace ToDoList.Controls.MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailToDoPage : ContentPage
	{
        public Note Note { get; set; }

        public DetailToDoPage (Note note)
		{
			InitializeComponent ();
            this.Note = note;
            BindingContext = this;
		}

        private async void Update_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateCommand", Note);
            await Navigation.PopModalAsync();
        }

        private async void Remove_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "RemoveCommand", Note.NoteId);
            await Navigation.PopModalAsync();
        }
    }
}