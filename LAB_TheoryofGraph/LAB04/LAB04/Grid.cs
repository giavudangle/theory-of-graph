using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB04
{
    class Grid
    {
        private int[] matrix;
        private int n;
        private int m;
        private int i1, j1, i2, j2;

        public void ReadData(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                string[] tokens = sr.ReadLine().Split(' ');
                n = int.Parse(tokens[0]);
                m = int.Parse(tokens[1]);
                tokens = sr.ReadLine().Split(' ');
                i1 = int.Parse(tokens[0]);
                i2 = int.Parse()
                        
            }
        }


    }
}
