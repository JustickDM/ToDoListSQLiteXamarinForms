using ToDoList.Models;
using Xamarin.Forms;

namespace ToDoList.Controls.MasterDetail.Views
{
	public partial class ToDoListPage : ContentPage
	{
		public ToDoListPage ()
		{
			InitializeComponent ();
		}

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var note = (Note)e.SelectedItem;
                //await Navigation.PushModalAsync(new NavigationPage(new DetailToDoPage(note)));
                List.SelectedItem = null;
            }
        }

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewToDoPage()));
        }
    }
}

