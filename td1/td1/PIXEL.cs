using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    

        public class Pixel
        {
            byte red;
            byte green;
            byte blue;

            public Pixel(byte r, byte g, byte b)
            {
                this.red = r;
                this.green = g;
                this.blue = b;
            }
            public int R
            {
                get { return red; }
            }
            public int G
            {
                get { return green; }
            }
            public int B
            {
                get { return blue; }
            }
            public string toString()
            {
                return "R" + red + " G" + green + " B" + blue;
            }


        }
    }

