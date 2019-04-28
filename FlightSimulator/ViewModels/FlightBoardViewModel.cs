using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        public FlightBoardViewModel()
        {
            InfoServer.Instance.PropertyChanged += Property;
        }

        private void Property(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        public double Lon
        {
            get { return InfoServer.Instance.Lon; }
        }

        public double Lat
        {
            get { return InfoServer.Instance.Lat; }
        }
    }
}
