using CollegeMajorsMVVM.Models;
using CollegeMajorsMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMajorsMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        public OverviewViewModel viewModel;
        public OverviewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new OverviewViewModel();

            lvwMajors.ItemSelected += OnItemSelected;
        }

        public OverviewPage(OverviewViewModel ovm)
        {
            InitializeComponent();
            BindingContext = viewModel = ovm;

            lvwMajors.ItemSelected += OnItemSelected;
        }
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Major major = lvwMajors.SelectedItem as Major;
            if (major != null)
            {
                await Navigation.PushAsync(new MajorPage(new MajorViewModel(major)));
            }
            lvwMajors.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Majors == null||viewModel.Majors.Count == 0)
                viewModel.LoadMajorsCommand.Execute(null);
        }
    }
}