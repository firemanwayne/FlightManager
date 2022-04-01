using Desktop.Pages;
using System;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IServiceProvider _sp;

        public MainWindow(IServiceProvider _sp)
        {           
            this._sp = _sp;

            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FlightManagerButton_Click(object sender, RoutedEventArgs e)
        {
            var fm = new FlightManager(_sp);

            fm.Show();

            Close();
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new CheckIn(_sp);

            c.Show();

            Close();
        }

        private void PurchaseTicketButton_Click(object sender, RoutedEventArgs e)
        {
            var p = new PurchaseTicket(_sp);

            p.Show();

            Close();
        }
    }
}
