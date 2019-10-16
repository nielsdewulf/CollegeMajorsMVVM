using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CollegeMajorsMVVM.Models;
using CollegeMajorsMVVM.ViewModels;

namespace CollegeMajorsMVVM.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

        }
        public async Task ChangeCategory(string cat)
        {

            Detail = new NavigationPage(new OverviewPage(new OverviewViewModel(cat)));
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);
            IsPresented = false;
        }
        
    }
}