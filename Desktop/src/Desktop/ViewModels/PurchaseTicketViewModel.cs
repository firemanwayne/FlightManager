using Desktop.Pages;
using Desktop.Shared;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class PurchaseTicketViewModel : ViewModelBase
    {
        public PurchaseTicketViewModel(PurchaseTicket _window) : base(_window)
        {
            _ = Task.Run(async () =>
            {
                await InitializeSignalR();
            });
        }
    }
}
