using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SeeAll.config
{
    class ConfigNetwork
    {
        private IPAddress ipAddr;
        private IPEndPoint ipEndPoint;
        private int port;
        public IPAddress IpAddr { get { return this.ipAddr; } }
        public int Port { get { return this.port; } }
        public IPEndPoint IpEndPoint { get { return this.ipEndPoint; } }
        public ConfigNetwork(string ipAddress,int port)
        {
            this.port = port;
            this.ipAddr = IPAddress.Parse(ipAddress);
            this.ipEndPoint = new IPEndPoint(this.ipAddr, this.port);
        }
        public ConfigNetwork()
        {
            this.ipAddr = IPAddress.Parse(Properties.Settings.Default.ipAdress);
            this.port = Properties.Settings.Default.port;
            this.ipEndPoint = new IPEndPoint(this.ipAddr, this.port);
        }
    }
}
