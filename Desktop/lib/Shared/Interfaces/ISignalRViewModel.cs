using Microsoft.AspNetCore.SignalR.Client;

namespace Desktop.Shared.Interfaces
{
    public interface ISignalRViewModel : IViewModel
    {
        Task SendAlert();
        Task Reconnect();
        Task Disconnect();

        HubConnectionState ConnectionState { get; }
        string TextColorSelection { get; set; }
        string BackgroundColorSelection { get; set; }
        string AlertMessageTextBoxValue { get; set; }
    }
}
