using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Windows.Input;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    class SettingsClickedViewModel
    {
        private ICommand settingsClicked;
        public ICommand getWindow
        {
            get
            {
                return settingsClicked ?? (settingsClicked = new CommandHandler(() => mission()));
            }
        }

        private void mission()
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
