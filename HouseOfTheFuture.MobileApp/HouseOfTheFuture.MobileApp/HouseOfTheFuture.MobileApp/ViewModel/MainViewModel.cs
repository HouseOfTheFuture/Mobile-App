﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HouseOfTheFuture.MobileApp.Common;
using HouseOfTheFuture.MobileApp.Sockets;

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

        private async void ShowMessage()
        {
            var devices = (await ServiceResolver.Resolve<IDeviceDiscoveryService>().GetDevices()).ToList();
            Message = "Hello World";
        }
    }
}
