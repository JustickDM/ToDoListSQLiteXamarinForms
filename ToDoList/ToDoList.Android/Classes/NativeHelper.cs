using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ToDoList.Droid.Classes;
using ToDoList.Interfaces;


[assembly: Xamarin.Forms.Dependency(typeof(NativeHelper))]
namespace ToDoList.Droid.Classes
{
    public class NativeHelper: INativeHelper
    {
        public void CloseApp()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}