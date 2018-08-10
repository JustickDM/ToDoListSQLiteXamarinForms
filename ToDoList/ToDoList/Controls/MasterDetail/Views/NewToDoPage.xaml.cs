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
        private Note Note = new Note();

        public NewToDoPage ()
		{
			InitializeComponent ();
		}

        private void Save_Clicked(object sender, EventArgs e)
        {
            Note.NoteText = enNoteText.Text;
            Note.NoteDateTimeStart = dpNoteStart.Date;
            Note.NoteDateTimeFinish = dpNoteStart.Date;
        }
    }
}