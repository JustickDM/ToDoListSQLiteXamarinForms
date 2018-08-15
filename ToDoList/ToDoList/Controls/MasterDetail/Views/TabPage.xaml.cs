using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Controls.MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        public TabPage ()
        {
            InitializeComponent();

            tabPage.Children.Add(new ToDoListPage());
            tabPage.Children.Add(new NewToDoPage());
        }
    }
}