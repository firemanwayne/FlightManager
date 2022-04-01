using Desktop.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;

namespace Desktop.Pages
{
    /// <summary>
    /// Interaction logic for FlightManager.xaml
    /// </summary>
    public partial class FlightManager : Window
    {
        readonly IServiceProvider _sp;
        readonly FlightManagerViewModel _model;

        public FlightManager(IServiceProvider _sp)
        {
            this._sp = _sp;

            _model = new FlightManagerViewModel(this);

            _model.PropertyChanged += (o, a) =>
            {
                if (!string.IsNullOrEmpty(a.PropertyName))
                    if (a.PropertyName.Equals(nameof(_model.ConnectionState)))
                    {
                        SignalRConnectionStatus.Content = _model.ConnectionState.ToString();

                        if (_model.ConnectionState != HubConnectionState.Connected)
                        {
                            SignalRDisconnectButton.Visibility = Visibility.Hidden;
                            SignalRConnectButton.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            SignalRDisconnectButton.Visibility = Visibility.Visible;
                            SignalRConnectButton.Visibility = Visibility.Hidden;
                        }
                    }
            };

            InitializeComponent();
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
    }
}
