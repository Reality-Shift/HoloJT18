using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace QRCodeScanner
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;
            if (!File.Exists(args[0]))
                return;
            var bmp = Image.FromFile(args[0]) as Bitmap;
            var reader = new BarcodeReader();

            var result = reader.Decode(bmp);
            if (result != null)
                Console.WriteLine(result.Text);

        }
    }
}
