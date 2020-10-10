using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB_TheoryofGraph
{
    class ListEdgeGraph
    {
        private int nVertex;
        private int nEdge;
        private List<List<int>> adjList;
        public List<List<int>> AdjList { get => adjList; set => adjList = value; }
        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }

        public void ReadDataGraph(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string[] input = reader.ReadLine().Split();
                NVertex = int.Parse(input[0]);
                NEdge = int.Parse(input[1]);

                adjList = new List<List<int>>(NEdge);
                for(int i = 0; i < NEdge; i++)
                {
                    input = reader.ReadLine().Split();
                    List<int> temp = new List<int>();
                    for (int j = 0; j < input.Length; j++)
                    {
                        temp.Add(int.Parse(input[j]));
                    }
                    AdjList.Add(temp);
                }
                Console.Write(AdjList);              
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ReadDataGraph2(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string[] input = reader.ReadLine().Split();
                NVertex = int.Parse(input[0]);
                NEdge = int.Parse(input[1]);

                adjList = new List<List<int>>(NEdge + 1000);

                for (int i = 0; i < NEdge; i++)
                {
                    input = reader.ReadLine().Split();
                    AdjList[i] = new List<int>();
                    int u = int.Parse(input[0]);
                    int v = int.Parse(input[1]);
                    AdjList[u].Add(v);
                    AdjList[v].Add(u);
                }
                Console.Write(AdjList);
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
            int[] counter = new int[100];
            for(int i = 0; i < AdjList.Count; i++)             
                for(int j = 0; j < AdjList[i].Count; j++)                   
                //int x = AdjList[i][j];
                    counter[AdjList[i][j]]++;                  
            for(int i = 0; i < counter.Length; i++)
            {
                if(counter[i]>0)
                {
                    sw.Write(counter[i] + " ");
                }
            }
            sw.Close();
        }
    }
}
