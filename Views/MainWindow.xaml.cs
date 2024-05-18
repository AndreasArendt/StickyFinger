using StickyFinger.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickyFinger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mMainViewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.mMainViewModel = new MainViewModel();
            this.mMainViewModel.OnEditableChange += MainViewModel_OnEditableChange;
            DataContext = this.mMainViewModel;
        }

        private void MainViewModel_OnEditableChange(object sender, EditableEventArgs e)
        {
            if (!e.Editable) 
            {
                this.Topmost = true;
                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, this.mMainViewModel.Rotate(0)); // definetly stop animation
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.mMainViewModel.Editable)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
        }

        private void ControlPanel_OnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.mMainViewModel.Editable ^= true;
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (this.mMainViewModel.Editable)
            {
                // delta seems to be always ~120 - increment in 5deg steps            
                var animation = this.mMainViewModel.Rotate(e.Delta / 120 * 5);
                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
            }
        }
    }
}
