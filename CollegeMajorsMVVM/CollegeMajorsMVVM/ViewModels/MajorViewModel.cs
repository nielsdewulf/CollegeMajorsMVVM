using CollegeMajorsMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMajorsMVVM.ViewModels
{
    public class MajorViewModel : BaseViewModel
    {
        Major _major;
        public Major Major
        {
            get { return _major; }
            set { SetProperty(ref _major, value); }
        }
        public MajorViewModel(Major major)
        {
            Title = major.Name;
            Major = major;
        }
    }
}
