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
        Color averageColor;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string WallpaperPth = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "Wallpaper", 0).ToString(); // Get the wallpaper path.

            System.Drawing.Bitmap btm = new System.Drawing.Bitmap(WallpaperPth); //Creating a new bitmap for the wallpaper.

            labelAVGLabel.Text = getDominantColor(btm).ToString(); //Get the AVG color and display it.

            averageColor = getDominantColor(btm);

            float hue = (averageColor.GetHue() + 180) % 360; // Get HSB values in order to calculate complimentary
            float saturation = averageColor.GetSaturation();
            float brightness = averageColor.GetBrightness();

            colorButton.ForeColor = averageColor;
            colorButton.BackColor = averageColor;

            HSL firstHSL = RGBToHSL(averageColor);
            HSL secondHSL = calculateTheOppositeHue(firstHSL);
            Color compColor = HSLToRGB(secondHSL);

            compButton.BackColor = compColor;
            compButton.ForeColor = compColor;
            labelCompColor.Text = compColor.ToString();
            labelCompColor.Text = compColor.ToKnownColor().ToString();
            
        }

        public static Color getDominantColor(Bitmap bmp)
        {
            //Used for tally
            long r = 0;
            long g = 0;
            long b = 0;

            long total = 0;

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

            return Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
        }

        public static HSL RGBToHSL(Color RGB)  //RGBToHSL is working fine, as intended.
        {
            HSL localHSL = new HSL();
            
            double varR = Convert.ToDouble(RGB.R) / 255.0d;
            double varG = Convert.ToDouble(RGB.G) / 255.0d;
            double varB = Convert.ToDouble(RGB.B) / 255.0d;

            double minVal = Math.Min(Math.Min(varR, varG), varB);//Min. value of RGB
            double maxVal = Math.Max(Math.Max(varR, varG), varB);//Max. value of RGB
            double maxDel = maxVal - minVal;//Delta RGB value

            localHSL.L = (maxVal + minVal) / 2.0d;

            if (maxDel == 0.0d)                     //This is a gray, no chroma...
            {
                localHSL.H = 0.0d;                  //HSL results from 0 to 1
                localHSL.S = 0.0d;
            }
            else                                    //Chromatic data...
            {
                if (localHSL.L < 0.5d)
                    localHSL.S = maxDel / (maxVal + minVal);
                else
                    localHSL.S = maxDel / (2.0d - maxVal - minVal);


                double delR = (((maxVal - varR) / 6.0d) + (maxDel / 2.0d)) / maxDel;
                double delG = (((maxVal - varG) / 6.0d) + (maxDel / 2.0d)) / maxDel;
                double delB = (((maxVal - varB) / 6.0d) + (maxDel / 2.0d)) / maxDel;

                if (varR == maxVal)
                    localHSL.H = delB - delG;
                else if (varG == maxVal)
                    localHSL.H = (1.0d / 3.0d) + delR - delB;
                else if (varB == maxVal)
                    localHSL.H = (2.0d / 3.0d) + delG - delR;


                if (localHSL.H < 0.0d)  //Getting Hue between 0 and 1.
                    localHSL.H += 1.0d;
                if (localHSL.H > 1.0d)
                    localHSL.H -= 1.0d;

            }

               

                return localHSL;
        }

        public HSL calculateTheOppositeHue(HSL normalHSL) //This piece of code is working fine, as intended.
        {
            HSL newHue = normalHSL;

            newHue.H = (newHue.H + 0.5d) % 1.0d;

            return newHue;
        }

        public Color HSLToRGB(HSL hsl) //HSLToRGB working as intended.
        {                                                     
            double R;
            double B;
            double G;

            double var_1;
            double var_2;

            if (hsl.S == 0.0d)                       //HSL from 0 to 1
            {
                R = hsl.L * 255.0d;                      //RGB results from 0 to 255
                G = hsl.L * 255.0d;
                B = hsl.L * 255.0d;
            }
            else
            {
                if (hsl.L < 0.5d)
                    var_2 = hsl.L * (1.0d + hsl.S);
                else
                    var_2 = (hsl.L + hsl.S) - (hsl.S * hsl.L);

                var_1 = 2.0d * hsl.L - var_2;

                R = 255.0d * HueToRGB(var_1, var_2, hsl.H + (1.0d / 3.0d));
                G = 255.0d * HueToRGB(var_1, var_2, hsl.H);
                B = 255.0d * HueToRGB(var_1, var_2, hsl.H - (1.0d / 3.0d));
            }
            Color cl = Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));

            return cl;
        }

        public double HueToRGB(double v1, double v2, double vH) //Don't think any problems here.
        {
            if (vH < 0.0d)      
                vH += 1.0d;
            if (vH > 1.0d)
                vH -= 1.0d;   //Getting hue back in between 0 and 1.
            if ((6.0d * vH) < 1.0d)
                return (v1 + (v2 - v1) * 6.0d * vH);
            if ((2.0d * vH) < 1.0d)
                return (v2);
            if ((3.0d * vH) < 2.0d)
                return (v1 + (v2 - v1) * ((2.0d / 3.0d) - vH) * 6.0d);
            return (v1);
        }
    }

    public class HSL
    {
        public double H;
        public double S;
        public double L;
    }

}
