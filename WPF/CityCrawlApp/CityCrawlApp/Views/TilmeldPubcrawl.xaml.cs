using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CityCrawlApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterPubcrawl.xaml
    /// </summary>
    public partial class TilmeldPubcrawl : Window
    {
        public TilmeldPubcrawl(ViewModels.TilmeldPubcrawlViewModel vmTilmeld)
        {
            InitializeComponent();
            DataContext = vmTilmeld;
            Closing += TilmeldPubcrawl_Closing;
            myCalendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(1111, 1, 1), DateTime.Now.AddDays(-1)));
        }

        private void TilmeldPubcrawl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;

        }

        private void MenuItemShowProfile_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if(Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }
    }
 
}
