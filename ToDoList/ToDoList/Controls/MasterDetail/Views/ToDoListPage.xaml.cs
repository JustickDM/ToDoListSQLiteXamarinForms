using ToDoList.Models;
using Xamarin.Forms;

namespace ToDoList.Controls.MasterDetail.Views
{
	public partial class ToDoListPage : ContentPage
	{
        private Note selectedNote;

		public ToDoListPage()
		{
			InitializeComponent();
		}

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedNote = (Note)e.SelectedItem;
                await Navigation.PushAsync(new DetailToDoPage(selectedNote));
                List.SelectedItem = null;
            }
        }

        private async void Remove_Clicked(object sender, System.EventArgs e)
        {
            var btn = (Button)sender;
            var note = (Note)btn.BindingContext;
            bool result = await DisplayAlert("Confirm action", "Do you want to delete the entry?", "Yes", "No");
            if (result)
            {
                MessagingCenter.Send(this, "RemoveCommand", note.NoteId);
            }
        }
    }
}

