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
        private bool mEditable;
        public bool Editable
        {
            get
            {
                return this.mEditable;
            }
            set
            {
                SetProperty(ref this.mEditable, value);
            }
        }

        public MainViewModel()
        {
            this.Editable = true;
        }
    }
}

