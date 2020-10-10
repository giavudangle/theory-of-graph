using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace LAB02
{
    class MatrixAdjacency
    {
        private int nVertex;
        private int nEdge;
        private int[,] adjMatrix;
        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }
        public int[,] AdjMatrix { get => adjMatrix; set => adjMatrix = value; }

        public MatrixAdjacency()
        {

        }

        public void ReadDataGraph(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                NVertex = int.Parse(reader.ReadLine());
                AdjMatrix = new int[NVertex, NVertex];
                for (int i = 0; i < NVertex; i++)
                {
                    string[] tokens = reader.ReadLine().Split();
                    for (int j = 0; j < NVertex; j++)
                        adjMatrix[i, j] = int.Parse(tokens[j]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void FindListVertex_NotHaveOutDegree(int[,] inputMatrix,string path)
        {           
            int inDegree = 0, outDegree = 0;
            List<int> listVertex = new List<int>(NVertex);
            int k = 0;
            for (int i = 0; i < NVertex; i++)
            {
                inDegree = 0;
                outDegree = 0;
                for (int j = 0; j < NVertex; j++)
                {
                    if (AdjMatrix[j, i] > 0)
                        inDegree++;
                    if (AdjMatrix[i, j] > 0)
                        outDegree++;
                }
                if (inDegree > 0 && outDegree == 0)
                {
                    k++;
                    listVertex.Add(i + 1);
                }                   
            }

            using (StreamWriter sw = new StreamWriter(path)) {
                if (k > 0)
                {
                    sw.WriteLine(k);
                    listVertex.Sort();
                    foreach (int x in listVertex)
                        sw.Write(x + " ");
                }
                else
                {
                    sw.Write(0);
                }
            }
           
        }
    }
}
