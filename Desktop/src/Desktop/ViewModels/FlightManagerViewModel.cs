using Desktop.Pages;
using Desktop.Shared;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class FlightManagerViewModel : ViewModelBase
    {          
        public FlightManagerViewModel(FlightManager window) : base(window)
        {            
            _ = Task.Run(async () =>
            {
                await InitializeSignalR();
            });
        }              
    }
}
