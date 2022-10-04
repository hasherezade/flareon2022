using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlareOn.Backdoor;

namespace ConsoleApp1
{

    class Program
    {
        static bool decodeAndSave(Dictionary<uint, int> m, byte[] b, String filename)
        {
            bool isOk = false;
            byte[] outs = FLARE15.flare_71(m, b);
            if (outs.Length != 0)
            {
                isOk = true;
            } else
            {
                Console.Write("Decodeding failed:" + filename + "\n");
            }
            File.WriteAllBytes(filename, outs);
            return isOk;
        }


        static void Main(string[] args)
        {
            FLARE15.flare_74();

            decodeAndSave(FLARE15.gh_m, FLARE15.gh_b, "C:\\decoded\\flared_66.bin");
            decodeAndSave(FLARE15.d_m, FLARE15.d_b, "C:\\decoded\\flared_47.bin");
            decodeAndSave(FLARE15.gs_m, FLARE15.gs_b, "C:\\decoded\\flared_69.bin");
            decodeAndSave(FLARE15.cl_m, FLARE15.cl_b, "C:\\decoded\\flared_67.bin");
            decodeAndSave(FLARE15.pe_m, FLARE15.pe_b, "C:\\decoded\\flared_35.bin");
            decodeAndSave(new Dictionary<uint, int>(), FLARE15.rt_b, "C:\\decoded\\flared_68.bin");

            //
            Console.Write("Decoded!\n");
        }
    }
}
