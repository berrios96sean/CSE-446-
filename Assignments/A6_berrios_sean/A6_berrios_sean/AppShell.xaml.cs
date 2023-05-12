using A6_berrios_sean.ViewModels;
using A6_berrios_sean.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace A6_berrios_sean
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
