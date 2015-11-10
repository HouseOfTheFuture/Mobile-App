using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HouseOfTheFuture.MobileApp.Common;
using HouseOfTheFuture.MobileApp.Sockets;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));
            _navigationService = navigationService;

            ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (!string.Equals(_message, value))
                {
                    _message = value;
                    RaisePropertyChanged();
                }
            }
        }

        public RelayCommand ShowMessageCommand { get; }

        private async void ShowMessage()
        {
            Message = "Hello World";
        }
    }
}
