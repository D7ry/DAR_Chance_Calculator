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
                Console.Write("equal chance? [Y/N]");
                List<float> _DARProbability = new List<float>();
                if (Console.ReadLine().ToLower() == "y")
                {
                    float target_P = 1 / folderCt;
                    float overwrite_P = 1.0f;
                    while (folderCt > 0)
                    {
                        float chance = target_P / overwrite_P;
                        _DARProbability.Add(chance);
                        folderCt--;
                        overwrite_P *= (1 - chance);
                    }
                } else
                {
                    var i = 1;
                    List<float> expected_P = new List<float>();
                    Console.WriteLine("input real probability expectation for DAR folders, starting from top folder(smallest number)");
                    while (i <= folderCt)
                    {
                        expected_P.Add(float.Parse(Console.ReadLine()));
                        Console.WriteLine("inputted " + i + " probabilities");
                        i++;
                    }
                    if (expected_P.Sum() > 1)
                    {
                        Console.WriteLine("Error: sum of expected probabilities cannot be bigger than 1.");
                    } else
                    {
                        float overwrite_P = 1.0f;
                        while (folderCt > 0)
                        {
                            float chance = expected_P[(int)folderCt - 1] / overwrite_P;
                            _DARProbability.Add(chance);
                            folderCt--;
                            overwrite_P *= (1 - chance);
                        }
                    }
                }
                Console.WriteLine("probability to put into Random(), starting from top folder(smallest number): ");
                int k = _DARProbability.Count();
                while (k > 0)
                {
                    Console.WriteLine(_DARProbability[k - 1]);
                    k--;
                }
                _DARProbability.Clear();
            }
        }
    }
}
