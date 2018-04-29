using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SeeAll
{
    class ScreenSt
    {
        IScreen screen;
        public ScreenSt(IScreen iscreen)
        {
            screen = iscreen;
        }

        public Bitmap GetBitmap()
        {
            return screen.GetScreen();
        }
    }
}
