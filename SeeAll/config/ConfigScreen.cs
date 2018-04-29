using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeAll.config
{
     class ConfigScreen
    {
        private int Width;
        private int Height;
        public int width { get { return this.Width; } }
        public int height { get { return this.Height; } }

        public ConfigScreen()
        {
            LoadScreenSize();
        }

        public  void ChangeScreenSize(int Width, int Height)
        {
           Properties.Settings.Default.ScreenSize = new System.Drawing.Size(Width, Height);
            LoadScreenSize();
        }
        public  void LoadScreenSize()
        {
            if (Properties.Settings.Default.ScreenSize.Width == 0 || Properties.Settings.Default.ScreenSize.Height == 0)
            {
                Properties.Settings.Default.ScreenSize = new System.Drawing.Size(640, 480);
            }
            this.Width = Properties.Settings.Default.ScreenSize.Width;
            this.Height = Properties.Settings.Default.ScreenSize.Height;
        }

        public  void SaveScreenSize()
        {
            Properties.Settings.Default.Save();
        }
    }
}
