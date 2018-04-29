using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SeeAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen scr = new Screen();
            ScreenSt start = new ScreenSt(scr);
            config.ConfigScreen cfg = new config.ConfigScreen();

            var bmp =Resize.ResizeImage( start.GetBitmap(),cfg.width, cfg.height);
            config.ConfigNetwork cfgntw =new config.ConfigNetwork("127.0.0.1",45013);
           
            //SocketServer srv = new SocketServer(cfgntw);

            SocketClient cl = new SocketClient(cfgntw);
           

            while(true)
            {
                cl.SendMessage();
               
            }
            cl.CloseSocket();
        }
    }
}
