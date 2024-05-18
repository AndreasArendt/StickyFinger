using GroundControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace StickyFinger.ViewModels
{
    public class EditableEventArgs
    {
        public EditableEventArgs(bool editable) { Editable = editable; }
        public bool Editable { get; } // readonly
    }

    internal class MainViewModel : ViewModelBase
    {
        
        public delegate void EditableEventHandler(object sender, EditableEventArgs e);                
        public event EditableEventHandler OnEditableChange;

        private bool mEditable;
        public bool Editable
        {
            get { return this.mEditable; }
            set 
            { 
                this.SetProperty(ref this.mEditable, value);
                OnEditableChange?.Invoke(this, new EditableEventArgs(this.mEditable));
            }
        }

        private int mRotation;
        public int Rotation
        {
            get { return this.mRotation; }
            set 
            {
                // Angle Wrap
                value = value % 360; 
                this.SetProperty(ref this.mRotation, value); 
            }
        }

        public MainViewModel()
        {
            this.Editable = true;
            this.Rotation = 0;
        }

        public DoubleAnimation Rotate(int deg)
        {
            this.Rotation += deg;
            
            DoubleAnimation animation = new DoubleAnimation
            {
                From = this.Rotation,
                To = this.Rotation + deg,
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            return animation;
        }
    }
}

