using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMv1.Views;

namespace MVVMv1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CarsListPage()); ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
