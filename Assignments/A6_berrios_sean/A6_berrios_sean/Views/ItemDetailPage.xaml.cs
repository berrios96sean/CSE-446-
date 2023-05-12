using A6_berrios_sean.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace A6_berrios_sean.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}