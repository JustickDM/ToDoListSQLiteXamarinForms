using System;
using ToDoList.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoList.ViewModels;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ToDoList
{
	public partial class App : Application
	{
		public App(INotesRepository notesRepository)
		{
			InitializeComponent();

            MainPage = new ToDoList.Controls.MasterDetail.Views.MainPage()
            {
                BindingContext = new ToDoListViewModel(notesRepository),
            };
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
