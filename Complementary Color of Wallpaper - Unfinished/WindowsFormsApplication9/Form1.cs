using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string WallpaperPth = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "Wallpaper", 0).ToString(); // Get the wallpaper path.

            System.Drawing.Bitmap btm = new System.Drawing.Bitmap(WallpaperPth); //Creating a new bitmap for the wallpaper.
          
            label2.Text = getDominantColor(btm).ToString(); //Get the AVG color and display it.

            label4.Text = getDominantColor(btm).ToKnownColor().ToString();

            float hue = ( getDominantColor(btm).GetHue() + 180 ) % 360; // Get HSB values in order to calculate complimentary
            float saturation = getDominantColor(btm).GetSaturation();
            float brightness = getDominantColor(btm).GetBrightness();

        }

        public static Color getDominantColor(Bitmap bmp)  
        {
            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);
                    r += clr.R;
                    g += clr.G;
                    b += clr.B;
                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
    }
}
