using System.ComponentModel;
using Xamarin.Forms;
using XFormsMonitorCallNumber.ViewModels;

namespace XFormsMonitorCallNumber.Views
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