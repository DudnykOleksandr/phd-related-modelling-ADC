using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabViewDllNet;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conv = new ConversionClass(26);

            byte[] mas = { 139, 52, 27, 139, 53, 27, 139, 54, 27, 139, 55, 27, 139, 56, 27, 139, 53, 27, 139, 56, 47, 139, 66, 47 };
            int erros = 0;
            int num = 0;
            
            int res;

            do
            {
                res = conv.Conversion(mas,(uint)mas.Length, true,ref erros);

                if (res > 6)
                {
                    var resArray = conv.Read(0,10);
                }
            }
            while (true);

            Console.WriteLine("Gotcha");

        }
    }
}
