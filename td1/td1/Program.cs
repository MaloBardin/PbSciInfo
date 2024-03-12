using System.Diagnostics;
using System.Drawing;


namespace td1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Bitmap FirstBitMap = new Bitmap("./Images/coucou.bmp");
            FirstBitMap.RotateFlip(RotateFlipType.Rotate180FlipX);
            FirstBitMap.Save("./Images/coucouuu.bmp");
            
         
         
        }
    }
}