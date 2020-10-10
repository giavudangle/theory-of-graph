/***
 * Matrix Adj
 * 
 * 
 * ***/


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace LAB_TheoryofGraph
{
    class MatrixAdjacencyGraph
    {
        private int nVertex;
        private int nEdge;
        private int[,] adjMatrix;

        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }
        public int[,] AdjMatrix { get => adjMatrix; set => adjMatrix = value; }
        
        public MatrixAdjacencyGraph(int v,int e)
        {
            NVertex = v;
            NEdge = e;
            AdjMatrix = new int[v, v];
        }

        public MatrixAdjacencyGraph()
        {

        }

        public MatrixAdjacencyGraph(int v)
        {
            NVertex = v;
            AdjMatrix = new int[v, v];
        }

        public void AddEdge(int u, int v)
        {
            AdjMatrix[u, v] = 1;
            AdjMatrix[v, u] = 1;
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
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void PrintGraph(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < NVertex; i++)
                {
                    for (int j = 0; j < NVertex; j++)
                        sw.Write(adjMatrix[i, j] + " ");
                    sw.WriteLine();
                }
            }          
        }

        // Method on Graph

        public void FindAllDegree(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                int degree = 0;
                sw.WriteLine(NVertex);
                for (int i = 0; i < NVertex; i++)
                {
                    degree = 0;
                    for (int j = 0; j < NVertex; j++)
                    {
                        if (AdjMatrix[i, j] == 1)
                            degree++;
                    }
                    sw.Write(degree + " ");
                }
            }
           
        }

        /*
         * As Matrix Adjagency
            - In degree -> number of integer(diff 0) of COL;
            - Out degree -> number of integer(diff 0) of ROW;
            Example :
                0 1 1 0 0 0
                0 0 0 1 1 0
                0 1 0 0 1 0
                0 0 0 0 1 1
                0 1 0 0 0 1
                0 0 0 0 0 0
            -> In Degree [2]  -> 3
            -> Out Degree [2] -> 2                 
         */
        public void FindInAndOutDegree(string path)
        {
            // List<int> inDegree = new List<int>();          
            

            using (StreamWriter sw = new StreamWriter(path))
            {
                int inDegree = 0, outDegree = 0;
                sw.WriteLine(NVertex);
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
                    sw.WriteLine(inDegree + " " + outDegree);
                }
            }
        }



    }
}
