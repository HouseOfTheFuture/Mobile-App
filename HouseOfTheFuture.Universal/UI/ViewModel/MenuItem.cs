using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace InfoSupport.TickTack.App.ViewModel
{
    public class MenuItem : ObservableObject
    {
        private string _glyph;
        private string _text;
        private RelayCommand _command;
        private Type _navigationDestination;

        public string Glyph
        {
            get { return _glyph; }
            set { Set(ref _glyph, value); }
        }

        public string Text
        {
            get { return _text; }
            set { Set(ref _text, value); }
        }

        public ICommand Command
        {
            get { return _command; }
            set { Set(ref _command, (RelayCommand)value); }
        }

        public Type NavigationDestination
        {
            get { return _navigationDestination; }
            set { Set(ref _navigationDestination, value); }
        }

        public bool IsNavigation => _navigationDestination != null;
    }
}
