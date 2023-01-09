using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Basic_App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Uri source;
        public Uri Source
        {
            get { return source; }
            set
            {
                source = value;
                //RaisePropertyChanged();
            }
        }
    }
}
