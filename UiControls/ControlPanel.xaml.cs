using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickyFinger.UiControls
{
    /// <summary>
    /// Interaktionslogik für ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : UserControl
    {
        public static readonly RoutedEvent CloseEvent = EventManager.RegisterRoutedEvent("CloseEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));
        public static readonly RoutedEvent SlideLeftEvent = EventManager.RegisterRoutedEvent("SlideLeftEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));
        public static readonly RoutedEvent SlideRightEvent = EventManager.RegisterRoutedEvent("SlideRightEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));

        public ControlPanel()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ControlPanel.CloseEvent));
        }

        public event RoutedEventHandler OnClose
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }

        public event RoutedEventHandler OnSlideLeft
        {
            add { AddHandler(SlideLeftEvent, value); }
            remove { RemoveHandler(SlideLeftEvent, value); }        
        }

        public event RoutedEventHandler OnSlideRight
        {
            add { AddHandler(SlideRightEvent, value); }
            remove { RemoveHandler(SlideRightEvent, value); }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var fingerWindow = new FingerWindow();
            fingerWindow.Show();
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ControlPanel.SlideLeftEvent));
        }

        private void RightRight_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ControlPanel.SlideRightEvent));
        }
    }
}
