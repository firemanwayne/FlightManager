using Desktop.Shared;
using Desktop.Shared.Interfaces;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.Controls.SignalR
{
    public class SignalRViewModel : ViewModelBase, ISignalRViewModel
    {
        private string textColorSelection = string.Empty;
        private string backgroundColorSelection = string.Empty;
        private string alertMessageTextBoxValue = string.Empty;
        private HubConnectionState connectionState;

        private HubConnection? hubConnection;
        readonly Window _window;

        public SignalRViewModel(MainWindow window)
        {            
            _window = window;

            _ = Task.Run(async () =>
            {
                await InitializeSignalR();
            });
        }

        private async Task InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7106/flighthub", HttpTransportType.WebSockets)
                .Build();

            hubConnection.Reconnecting += (exception) =>
            {
                UpdateConnectionState();

                return Task.CompletedTask;
            };

            hubConnection.Reconnected += (value) =>
            {
                UpdateConnectionState();

                return Task.CompletedTask;
            };

            hubConnection.Closed += async (error) =>
            {
                UpdateConnectionState();

                await Task.Delay(new Random().Next(0, 5) * 1000);

                await hubConnection.StartAsync();

                UpdateConnectionState();
            };

            try
            {
                await hubConnection.StartAsync();

                UpdateConnectionState();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        public async Task Reconnect()
        {
            if (hubConnection != null)
                if (hubConnection.State != HubConnectionState.Connected)
                {
                    try
                    {
                        await hubConnection.StartAsync();

                        UpdateConnectionState();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message);
                    }
                }
        }

        public async Task Disconnect()
        {
            if (hubConnection != null)
                await hubConnection.StopAsync();
        }

        public async Task SendAlert()
        {            
            if (hubConnection != null)
                await hubConnection.SendAsync("Publish");
        }

        public string BackgroundColorSelection
        {
            get => backgroundColorSelection;
            set
            {
                backgroundColorSelection = value;
                OnPropertyChanged();
            }
        }
        public string TextColorSelection
        {
            get => textColorSelection;
            set
            {
                textColorSelection = value;
                OnPropertyChanged();
            }
        }
        public string AlertMessageTextBoxValue
        {
            get => alertMessageTextBoxValue;
            set
            {
                alertMessageTextBoxValue = value;
                OnPropertyChanged();
            }
        }

        public HubConnectionState ConnectionState
        {
            get => connectionState;
            private set
            {
                connectionState = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected override void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UpdateConnectionState()
        {
            _window.Dispatcher.Invoke(() =>
            {
                if (hubConnection != null)
                {
                    ConnectionState = hubConnection.State;

                    _window.SignalRConnectionId.Content = hubConnection.ConnectionId;

                    _window.SignalRConnectionState.Content = ConnectionState.ToString();

                    if (ConnectionState != HubConnectionState.Connected)
                        _window.SignalRSubmitButton.IsEnabled = false;
                    else
                        _window.SignalRSubmitButton.IsEnabled = true;
                }
            });
        }
    }
}
