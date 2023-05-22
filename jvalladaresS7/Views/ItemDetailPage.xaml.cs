using jvalladaresS7.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace jvalladaresS7.Views
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