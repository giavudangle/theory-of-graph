using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace LAB02
{
    class GraphConverter
    {

        private int nVertex;
        private int nEdge;
        private int[,] adjMatrix;

        private List<int> vA;
        private List<int> vB;

        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }
        public int[,] AdjMatrix { get => adjMatrix; set => adjMatrix = value; }
        public List<int> VA { get => vA; set => vA = value; }
        public List<int> VB { get => vB; set => vB = value; }

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

        public LinkedList<int>[] ConvertFrom_AdjMatrix_To_AdjList(int[,] matrix)
        {
            LinkedList<int>[] adjList = new LinkedList<int>[NVertex];

            for(int i = 0; i < NVertex; i++)            
                adjList[i] = new LinkedList<int>();            
            for (int i = 0; i < NVertex; i++)             
                for (int j = 0; j < NVertex; j++)               
                    if (matrix[i, j] > 0)                   
                        adjList[i].AddLast(j+1);      
            return adjList;
        }
        
        public void ConvertFrom_AdjMatrix_To_EdgeList(int[,] matrix)
        {
            VA = new List<int>(NVertex * NVertex);
            VB = new List<int>(NVertex * NVertex);

            for(int i = 0; i < NVertex; i++)
            {
                for(int j = 0; j < NVertex; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        if (i + 1 <= j + 1)
                        {
                            vA.Add(i + 1);
                            vB.Add(j + 1);
                        }
                       
                    }
                } 
            }

        }

        public void PrintEdgeListGraph(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(VA.Count);
                for(int i = 0; i < VA.Count; i++)
                {
                    sw.WriteLine(VA[i] + " " + VB[i]);
                }
            }
        }

        public void PrintAdjListGraph(string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(NVertex);
                foreach(LinkedList<int> it in ConvertFrom_AdjMatrix_To_AdjList(AdjMatrix))
                {
                    foreach(int x in it)
                    {
                        sw.Write(x + " ");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
