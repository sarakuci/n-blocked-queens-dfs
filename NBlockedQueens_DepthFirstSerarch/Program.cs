using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NBlockedQueens_DepthFirstSerarch
{  
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Blocked N-Queens - Depth-First Search Algorithm");
                while (true)
                {
                    Console.Write("Shtypni numrin e mbretereshave: ");
                    int n = int.Parse(Console.ReadLine());


                    Queen objQueen = new Queen(n);
                    if (objQueen.Solution(0))
                    {
                        objQueen.Display();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }


                Console.ReadLine();
            }
        }

}
