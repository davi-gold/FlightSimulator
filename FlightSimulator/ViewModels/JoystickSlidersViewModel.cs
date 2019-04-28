using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoystickSlidersViewModel
    {
        public float throttle
        {
            set
            {
                ClientCommands.Instance.createClientThread("set controls/engines/current-engine/throttle " + value);
            }
        }

        public float rudder
        {
            set
            {
                ClientCommands.Instance.createClientThread("set controls/flight/rudder " + value);
            }
        }

        public float aileron
        {
            set
            {
                ClientCommands.Instance.createClientThread("set controls/flight/aileron " + value);
            }
        }

        public float elevator
        {
            set
            {
                ClientCommands.Instance.createClientThread("set controls/flight/elevator " + value);
            }
        }

    }
}
