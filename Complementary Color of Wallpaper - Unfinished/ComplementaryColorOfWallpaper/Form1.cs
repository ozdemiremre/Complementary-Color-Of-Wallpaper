﻿using System;
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

            label2.Text = getDominantColor(btm).ToString(); //Get the AVG color and display it.



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
            label4.Text = compColor.ToString();
            
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

        public static HSL RGBToHSL(Color RGB)
        {
            HSL localHSL = new HSL();
            
            double varR = Convert.ToDouble(RGB.R) / 255.0;
            double varG = Convert.ToDouble(RGB.G) / 255.0;
            double varB = Convert.ToDouble(RGB.B) / 255.0;

            double minVal = Math.Min(Math.Min(varR, varG), varB);//Min. value of RGB
            double maxVal = Math.Max(Math.Max(varR, varG), varB);//Max. value of RGB
            double maxDel = maxVal - minVal;//Delta RGB value

            localHSL.L = (maxVal + minVal) / 2.0;

            if (maxDel == 0.0)                     //This is a gray, no chroma...
            {
                localHSL.H = 0.0;                  //HSL results from 0 to 1
                localHSL.S = 0.0;
            }
            else                                    //Chromatic data...
            {
                if (localHSL.L < 0.5)
                    localHSL.S = maxDel / (maxVal + minVal);
                else
                    localHSL.S = maxDel / (2.0 - maxVal - minVal);


                double delR = (((maxVal - varR) / 6.0) + (maxDel / 2.0)) / maxDel;
                double delG = (((maxVal - varG) / 6.0) + (maxDel / 2.0)) / maxDel;
                double delB = (((maxVal - varB) / 6.0) + (maxDel / 2.0)) / maxDel;


                if (varR == maxVal)
                    localHSL.H = delB - delG;
                else if (varG == maxVal)
                    localHSL.H = (1.0 / 3.0) + delR - delB;
                else if (varB == maxVal)
                    localHSL.H = (2.0 / 3.0) + delG - delR;


                if (localHSL.H < 0.0)
                    localHSL.H += 1.0;
                if (localHSL.H > 1.0)
                    localHSL.H -= 1.0;
            }

            return localHSL;
        }

        public HSL calculateTheOppositeHue(HSL normalHSL)
        {
            HSL newHue = normalHSL;

            newHue.H = (newHue.H + 0.5) % 1.0;

            return newHue;
        }
        public Color HSLToRGB(HSL hsl)
        {
            double R;
            double B;
            double G;

            double var_1;
            double var_2;

            if (hsl.S == 0.0)                       //HSL from 0 to 1
            {
                R = hsl.L * 255.0;                      //RGB results from 0 to 255
                G = hsl.L * 255.0;
                B = hsl.L * 255.0;
            }
            else
            {
                if (hsl.L < 0.5)
                    var_2 = hsl.L * (1 + hsl.S);
                else
                    var_2 = (hsl.L + hsl.S) - (hsl.S * hsl.L);

                var_1 = 2.0 * hsl.L - var_2;

                R = 255.0 * HueToRGB(var_1, var_2, hsl.H + (1.0 / 3.0));
                G = 255.0 * HueToRGB(var_1, var_2, hsl.H);
                B = 255.0 * HueToRGB(var_1, var_2, hsl.H - (1.0 / 3.0));
            }
            Color cl = Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(B), Convert.ToInt32(G));

            return cl;
        }

        public double HueToRGB(double v1, double v2, double vH)
        {
            if (vH < 0.0)
                vH += 1.0;
            if (vH > 1.0)
                vH -= 1.0;
            if ((6.0 * vH) < 1.0)
                return (v1 + (v2 - v1) * 6.0 * vH);
            if ((2.0 * vH) < 1.0)
                return (v2);
            if ((3.0 * vH) < 2.0)
                return (v1 + (v2 - v1) * ((2.0 / 3.0) - vH) * 6.0);
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