using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFormsMonitorCallNumber.ViewModels;
using XFormsMonitorCallNumber.Views;

namespace XFormsMonitorCallNumber
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
