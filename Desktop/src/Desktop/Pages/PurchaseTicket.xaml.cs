using Desktop.ViewModels;
using System;
using System.Windows;

namespace Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PurchaseTicket.xaml
    /// </summary>
    public partial class PurchaseTicket : Window
    {
        readonly IServiceProvider _sp;
        readonly PurchaseTicketViewModel _model;

        public PurchaseTicket(IServiceProvider _sp)
        {
            this._sp = _sp;
            _model = new PurchaseTicketViewModel(this);

            InitializeComponent();
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new CheckIn(_sp);

            c.Show();

            Close();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var m = new MainWindow(_sp);

            m.Show();

            Close();
        }

        private void FlightManagerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        void SignalRConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(async () =>
            {
                await _model.Reconnect();
            });
        }

        void SignalRDisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(async () =>
            {
                await _model.Disconnect();
            });
        }
    }
}
