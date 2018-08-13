using System;
using Xamarin.Forms;
using ToDoList;
using ToDoList.Controls.MasterDetail.Views;
using ToDoList.Controls.MasterDetail.Items;
using ToDoList.ViewModels;

namespace ToDoList.Controls.MasterDetail.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.listView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                var page = 
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
