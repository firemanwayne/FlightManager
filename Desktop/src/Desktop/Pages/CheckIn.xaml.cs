using Desktop.ViewModels;
using System;
using System.Windows;

namespace Desktop.Pages
{
    /// <summary>
    /// Interaction logic for CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Window
    {
        readonly IServiceProvider _sp;
        readonly CheckInViewModel _model;

        public CheckIn(IServiceProvider _sp)
        {
            this._sp = _sp;

            _model = new CheckInViewModel(this);

            InitializeComponent();
        }
    }
}
