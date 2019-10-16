using CollegeMajorsMVVM.Models;
using CollegeMajorsMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollegeMajorsMVVM.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        public ObservableCollection<Major> Majors { get; set; } = new ObservableCollection<Major>();
        public Command LoadMajorsCommand { get; set; }
        public OverviewViewModel(string category)
        {
            Title = StringExtensions.FirstCharToUpper(category);
            LoadMajorsCommand = new Command(async () => await ExecuteLoadMajorsCommand());
        }
        public OverviewViewModel()
        {
            Title = "All";
            LoadMajorsCommand = new Command(async () => await ExecuteLoadMajorsCommand());
        }
        async Task ExecuteLoadMajorsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                if(Majors!=null)
                    Majors.Clear();
                List<Major> majorList;
                if (Title != "All")
                {
                    majorList = await DataStore.GetMajorsByCategory(Title);

                }
                else
                {
                    majorList = await DataStore.GetMajors();
                }

                foreach (Major major in majorList)
                {
                    Majors.Add(major);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
