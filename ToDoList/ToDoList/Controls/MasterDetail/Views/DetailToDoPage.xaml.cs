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
        private Note Note { get; set; }

        public DetailToDoPage (Note note)
		{
			InitializeComponent ();
            enNoteId.Text = note.NoteId.ToString();
            enNoteText.Text = note.NoteText;
            dpNoteStart.Date = note.NoteDateTimeStart.Date;
            dpNoteFinish.Date = note.NoteDateTimeFinish.Date;
		}

        private void Update_Clicked(object sender, EventArgs e)
        {
            Note.NoteId = int.Parse(enNoteId.Text);
            Note.NoteText = enNoteText.Text;
            Note.NoteDateTimeStart = dpNoteStart.Date;
            Note.NoteDateTimeFinish = dpNoteStart.Date;
            //viewModel.UpdateNote(Note);
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            //viewModel.RemoveNote(int.Parse(enNoteId.Text));
        }
    }
}