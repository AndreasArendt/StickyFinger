using GroundControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Linq;
using System.Collections;

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

        private ImageBrush mCurrentFinger;
        public ImageBrush CurrentFinger
        {
            get { return this.mCurrentFinger; }
            set { this.SetProperty(ref this.mCurrentFinger, value); }
        }

        private List<ImageBrush> mImages;

        public MainViewModel()
        {
            this.Editable = true;
            this.Rotation = 0;

            this.mImages = Application.Current.Resources
                .OfType<DictionaryEntry>()
                .Where(entry => entry.Value is ImageBrush)
                .Select(entry => entry.Value as ImageBrush)
                .OrderBy(imageBrush => System.IO.Path.GetFileName(((ImageBrush)imageBrush).ImageSource.ToString()))
                .ToList();

            this.CurrentFinger = this.mImages.FirstOrDefault();
        }

        public DoubleAnimation Rotate(int deg)
        {
            this.Rotation += deg;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = this.Rotation,
                To = this.Rotation + deg,
                Duration = new Duration(TimeSpan.FromSeconds(0.0)),                
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            return animation;
        }

        public void NextPointer()
        {
            int index = this.mImages.FindIndex(img => img == this.CurrentFinger);
            if (index == this.mImages?.Count - 1) 
            {
                index = 0;
            }
            else
            {
                index++;
            }

            this.CurrentFinger = this.mImages[index];       
        }

        public void PreviousPointer()
        {
            int index = this.mImages.FindIndex(img => img == this.CurrentFinger);
            if (index == 0)
            {
                index = this.mImages.Count-1;
            }
            else
            {
                index--;
            }

            this.CurrentFinger = this.mImages[index];
        }
    }
}

