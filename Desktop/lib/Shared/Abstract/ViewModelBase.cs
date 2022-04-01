using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Desktop.Shared
{
    public abstract class ViewModelBase : IViewModel
    {
        HubConnectionState connectionState;
        HubConnection? hubConnection;
        Window _window;

        protected ViewModelBase(Window _window)
        {
            this._window = _window;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        protected async Task InitializeSignalR()
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
        void UpdateConnectionState()
        {
            _window.Dispatcher.Invoke(() =>
            {
                if (hubConnection != null)                
                    ConnectionState = hubConnection.State;                
            });
        }
    }
}