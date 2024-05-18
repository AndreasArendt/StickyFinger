using GroundControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyFinger.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private bool mFixed;
        public bool Fixed
        {
            get
            {
                return this.mFixed;
            }
            set
            {
                SetProperty(ref this.mFixed, value);
            }
        }

        public MainViewModel()
        {
            this.Fixed = false;
        }
    }
}

