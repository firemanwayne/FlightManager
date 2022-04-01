using Desktop.Pages;
using Desktop.Shared;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.ViewModels
{
    public class CheckInViewModel : ViewModelBase
    {
        public CheckInViewModel(CheckIn _window) : base(_window)
        {
            _ = Task.Run(async () =>
            {
                await InitializeSignalR();
            });
        }
    }
}
