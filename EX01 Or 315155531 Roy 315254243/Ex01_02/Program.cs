using System;

namespace Ex01_02_and_03
{
    public class Program
    {
        public static void Run(int i_TreeSize = -1)
        {
            if (i_TreeSize > 0) 
            { 
                Tree.PrintTree(1, i_TreeSize, 'A');
            }
            else
            {
                Tree.PrintTree(1, Tree.GetTreeSize(), 'A');
            }
        }
    }
}