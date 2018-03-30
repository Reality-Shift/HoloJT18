using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using ZXing;

namespace Obj
{
    public class QRCode
    {
        public static string Decode(string fileName)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = @"C:\Users\maksa\source\repos\HoloJT18\Back\QRCodeScanner\bin\Debug\QRCodeScanner.exe",
                    Arguments =  fileName
                }
            };
            string output = "";
            p.OutputDataReceived += (S, E) => output += E.Data ?? "";
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
            return output;
        }
    }
}
