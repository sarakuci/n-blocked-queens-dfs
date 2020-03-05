using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlockedQueens_DepthFirstSerarch
{
    public class Queen
    {
        public int Nr; //Numri i mbretereshave
        public int[,] Board; //Tabela e shahut ku do te vendosen mbretereshat; 2D Array

        public Queen(int nr) //Konstruktori i klases Queen
        {
            Nr = nr;
            Board = new int[Nr, Nr]; //Inicializimi i tabeles me Nr - rreshta dhe Nr - kolona 
            for (int i = 0; i < Nr; i++)
                for (int j = 0; j < Nr; j++)
                    Board[i, j] = 0; //Fillimisht vendosen vlerat 0 ne tabele
            Random BlockedPos = new Random(); //Inicializimi i vlerave random per blocked positions

            int bp = BlockedPos.Next(2, 6); //Caktimi i range sa vlera me i marre blocked

            for (int k = 0; k < bp; k++)
            {
                int i = BlockedPos.Next(0, Nr); //Ne keto kolona vendosen vlerat 2 per blocked
                int j = BlockedPos.Next(0, Nr); //Ne keto rreshta vendosen vlerat 2 per blocked
                Board[i, j] = 2; //Override i tabeles ku do te vendoset vlera 2, pra mbishkruhet -1 ne vend te 0.
            }
        }
        //Specifikimi i levizjeve te mbretereshes -- Implementimi Depth-First Search
        public bool SafeMov(int row, int column)
        {
            int i, j;

            for (i = 0; i < column; i++)  //Rreshtat
                
             if (Board[row, i] == 1)
                 return false;
                

            for (i = row, j = column; i >= 0 && j >= 0; i--, j--) //DiagonaljaL
                
               if (Board[i, j] == 1)
                 return false;

            for (i = row, j = column; i < Nr && j >= 0; i++, j--) //DiagonaljaR  
                
               if (Board[i, j] == 1)
                  return false;
               

            return true;
        }

        // c qendron per column-kolona
        public bool Solution(int c)
        {
            if (c >= Nr) //Nese numri i kolones eshte i barabarte me Nr(nr of queens) atehere zgjidhja eshte kompletuar
            {
                return true;
            }
            for (int r = 0; r < Nr; r++) //r qendron per rows-rreshtat
            {
                if (SafeMov(r, c)) //A lejohet vendosja e mbretereshes ketu
                {
                    if (Board[r, c] != 2)
                    {
                        Board[r, c] = 1;
                        if (Solution(c + 1))
                        {
                            return true;
                        }
                        Board[r, c] = 0;
                    }
                }

            }
            return false;
        }
        //Shfaqja e rezultatit ne ekran
        public void Display()
        {
            for (int i = 0; i < Nr; i++)
            {
                for (int j = 0; j < Nr; j++)
                {
                    Console.Write(string.Format("{0,3}", Board[i, j] + " "));
                }
                Console.WriteLine();
            }

        }
    }
}
