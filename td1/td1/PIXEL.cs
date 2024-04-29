using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    

        public class Pixel
        {
            byte blue;
            byte green;
            byte red;
            
            

            public Pixel(byte b, byte g, byte r)
            {
                this.red = r;
                this.green = g;
                this.blue = b;
            }
            public int R
            {
                get { return red; }
                set { red = Convert.ToByte(value); }
            }
            public int G
            {
                get { return green; }
                set { green = Convert.ToByte(value); }

        }
        public int B
            {
                get { return blue; }
                set { blue = Convert.ToByte(value); }

        }
        public string ToString()
            {
                return "R" + red + " G" + green + " B" + blue;
            }


        }
    }

