using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAR_Equal_Chance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("How many DAR folders?");
                float folderCt = float.Parse(Console.ReadLine());
                float target_P = 1 / folderCt;
                float overwriteP = 1.0f;
                while (folderCt >= 1)
                {
                    float chance = target_P / overwriteP;
                    Console.WriteLine(chance);
                    folderCt--;
                    overwriteP *= (1 - chance);
                }
            }
        }
    }
}
