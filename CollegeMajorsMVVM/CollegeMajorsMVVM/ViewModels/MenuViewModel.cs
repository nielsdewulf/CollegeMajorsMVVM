using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollegeMajorsMVVM.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public Command LoadCategories { get; set; }
        public MenuViewModel()
        {
            LoadCategories = new Command(async () => await ExecuteLoadMajorsCommand());
        }
        async Task ExecuteLoadMajorsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                if (Categories != null)
                    Categories.Clear();
                List<string> categoryList;

                categoryList = await DataStore.GetUniqueCategories();


                foreach (string cat in categoryList)
                {
                    Categories.Add(cat);
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
