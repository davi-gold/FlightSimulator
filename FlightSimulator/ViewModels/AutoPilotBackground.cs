using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotBackground : BaseNotify
    {
        private string textBox;
        private ICommand _clearCommand;
        private ICommand _OKCommand;

        public AutoPilotBackground()
        {
            textBox = "";
        }

        public string Text
        {
            get
            {
                NotifyPropertyChanged("ChangeColorBackGround");
                return textBox;
            }
            set
            {
                textBox = value;
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
            textBox = "";
            NotifyPropertyChanged("Text");
        }

        public string ChangeColorBackGround
        {
            get { return (textBox == "") ? "White" : "Pink"; }
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

        }
    }
}