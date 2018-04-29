using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SeeHost
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketServer srv = new SocketServer();
            //SocketClient cl = new SocketClient();
            while(true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
