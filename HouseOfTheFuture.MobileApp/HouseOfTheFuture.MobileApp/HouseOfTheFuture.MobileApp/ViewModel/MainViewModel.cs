using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace HouseOfTheFuture.MobileApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
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

        private void ShowMessage()
        {
            Message = "Hello World";
        }
    }
}
