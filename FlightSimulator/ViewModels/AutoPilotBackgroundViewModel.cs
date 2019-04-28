using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotBackgroundViewModel : BaseNotify
    {
        private string setCommandText;
        private ICommand _clearCommand;
        private ICommand _OKCommand;

        public AutoPilotBackgroundViewModel()
        {
            setCommandText = "";
        }

        public string Text
        {
            get
            {
                NotifyPropertyChanged("ChangeColorBackGround");
                return setCommandText;
            }
            set
            {
                setCommandText = value;
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => ClearClick()));
            }
        }

        private void ClearClick()
        {
            setCommandText = "";
            NotifyPropertyChanged("Text");
        }

        public string ChangeColorBackGround
        {
            get { return (setCommandText == "") ? "White" : "Pink"; }
        }

        public ICommand OKCommand
        {
            get
            {
                return _OKCommand ?? (_OKCommand =
                new CommandHandler(() => OKClick()));
            }
        }

        private void OKClick()
        {
            //will send the setCommandText
            ClientCommands.Instance.createClientThread(setCommandText);
            setCommandText = "";
            NotifyPropertyChanged("Text");

        }
    }
}

