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
    public partial class NewToDoPage : ContentPage
    {
        public Note Note { get; set; }

        public NewToDoPage()
        {
            InitializeComponent();
            Note = new Note();
            BindingContext = this;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCommand", Note);
            Note.NoteText = string.Empty;
        }
    }
}