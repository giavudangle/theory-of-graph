using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB_TheoryofGraph
{
    class ListAdjacencyGraph
    {
        private int nVertex;
        private LinkedList<int>[] adjList;
        public int NVertex { get => nVertex; set => nVertex = value; }
        public LinkedList<int>[] AdjList { get => adjList; set => adjList = value; }

        public ListAdjacencyGraph()
        {

        }

        public void ReadDataGraph(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                NVertex = int.Parse(reader.ReadLine());
                AdjList = new LinkedList<int>[NVertex];

                for (int i = 0; i < NVertex; i++)
                {
                    string[] tokens = reader.ReadLine().Split();
                    AdjList[i] = new LinkedList<int>();
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (tokens[j] == "") continue;
                        AdjList[i].AddLast(int.Parse(tokens[j]));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void FindAllDegree(string path)
        {
            using StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(NVertex);
            foreach (var x in AdjList)
            {
                sw.Write(x.Count + " ");
            }
            sw.Close();
        }
    }
}
