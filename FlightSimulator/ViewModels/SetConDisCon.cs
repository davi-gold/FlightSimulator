using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Windows.Input;
using System.Threading;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    class SetConDisCon
    {
        private ICommand _connect;
        public ICommand connect
        {
            get
            {
                return _connect ?? (_connect = new CommandHandler(() => connectClicked()));
            }

        }
        //calling connect in model
        public void connectClicked()
        {
            //if is already connected, need to close 
            //the previous connection and create a new connections
            if (ClientCommands.Instance.isConnected)
            {
                new Thread(() =>
                {
                    ClientCommands.Instance.disconnect();
                    ClientCommands.Instance.connect();
                }).Start();
            }

            //else
            new Thread(() =>
            {
                //creating server side connection
                InfoServer.Instance.connect();
                //creating client side connection
                ClientCommands.Instance.connect();
            }).Start();
        }
         
        private ICommand _disconnect;
        public ICommand disconnect
        {
            get
            {
                return _disconnect ?? (_disconnect = new CommandHandler(() => disconnectClicked()));
            }
        }

        public void disconnectClicked()
        {
            new Thread(() =>
            {
                //closing server side connection
                InfoServer.Instance.disconnect();
                //closing client side connection
                ClientCommands.Instance.disconnect();
            }).Start();
        }

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
