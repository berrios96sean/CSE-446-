using A6_berrios_sean.Services;
using A6_berrios_sean.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A6_berrios_sean
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
