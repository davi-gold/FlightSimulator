using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace FlightSimulator.Model
{
    //class which connects connection for updating information
    class InfoServer : BaseNotify
    {
        //the client we're listening to
        TcpClient client;
        //TcpListener listener;
        bool isConnected;
        Thread listenThread;

        public double lon;
        public double Lon
        {
            set
            {
                if(lon!= value)
                {
                    lon = value;
                    NotifyPropertyChanged("Lon");
                }
            }
            get
            {
                return lon;
            }
        }

        public double lat;
        public double Lat
        {
            set
            {
                if (lat != value)
                {
                    Console.Write(lat);
                    lat = value;
                    NotifyPropertyChanged("Lat");
                }
            }
            get
            {
                return lat;
            }
        }

        public TcpListener listener
        {
            set;
            get;
        }


        private static InfoServer m_Instance = null;
        public static InfoServer Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new InfoServer();
                }
                return m_Instance;
            }
        }
        public InfoServer()
        {
            isConnected = false;
        }

        //server side connection
        public void connect()
        {
 
            Int32 port = ApplicationSettingsModel.Instance.FlightInfoPort;
            IPAddress ip = IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP);
            IPEndPoint ep = new IPEndPoint(ip, port);
            listener = new TcpListener(ep);
            listener.Start();
            client = listener.AcceptTcpClient();
            Console.WriteLine("Info channel: Client connected");
            isConnected = true;
            Thread thread = new Thread(() => listenAndRead());
            thread.Start();
        }

        //this should be simluator sending me the info but i don't think it's working
        public void listenAndRead()
        {
            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;
            NetworkStream stream = client.GetStream();
            int i;
            while (isConnected)
            {
                if (client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[client.ReceiveBufferSize];
                    stream.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    if (msg!=null && msg.Contains(","))
                    {
                        Lon = float.Parse(msg.Split(',')[0]);
                        Lat = float.Parse(msg.Split(',')[1]);
                    }
                }

            }
            stream.Close();
            client.Close();
        }

        public void disconnect()
        {
            //will stop while loop
            isConnected = false;
            //client.Close();
            listener.Stop();
        }
    }
}