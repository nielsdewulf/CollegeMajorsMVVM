using CollegeMajorsMVVM.Models;
using CollegeMajorsMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMajorsMVVM.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public MenuViewModel view;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = this.view = new MenuViewModel();
            
            lvwFilters.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                await RootPage.ChangeCategory(e.SelectedItem.ToString());
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (view.Categories == null||view.Categories.Count == 0)
                view.LoadCategories.Execute(null);
        }
    }
}