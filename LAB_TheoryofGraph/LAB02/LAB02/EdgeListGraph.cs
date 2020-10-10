using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
namespace LAB02
{
    class EdgeListGraph
    {
        private int nVertex;
        private int nEdge;
        private LinkedList<int>[] adjList;
        private LinkedList<int>[] edgeList;

        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }
        public LinkedList<int>[] EdgeList { get => edgeList; set => edgeList = value; }

        public LinkedList<int>[] AdjList { get => edgeList; set => edgeList = value; }

        public EdgeListGraph() { }

        public void ReadData_EdgeList(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string[] temp = sr.ReadLine().Split(' ');
                NVertex = int.Parse(temp[0]);
                NEdge = int.Parse(temp[1]);

                EdgeList = new LinkedList<int>[NVertex + 5];

                for (int i = 0; i < NEdge; i++)
                    EdgeList[i] = new LinkedList<int>();

                for (int i = 1; i <= NEdge; i++)
                {
                    temp = sr.ReadLine().Split(' ');
                    int u = int.Parse(temp[0]);
                    int v = int.Parse(temp[1]);
                    EdgeList[u].AddLast(v);
                    EdgeList[v].AddLast(u);

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ReadData_AdjList(string path)
        {
            StreamReader sr = new StreamReader(path);

            NVertex = int.Parse(sr.ReadLine());
            AdjList = new LinkedList<int>[NVertex];

            for (int i = 0; i < NVertex; i++)
            {
                string[] tokens = sr.ReadLine().Split(' ');
                AdjList[i] = new LinkedList<int>();

                for (int j = 0; j < tokens.Length; j++)
                {
                    if (tokens[j] == "") continue;
                    AdjList[i].AddLast(int.Parse(tokens[j]));
                }
            }
            sr.Close();
        }

        public void Convert_From_AdjacencyList_To_EdgeList(LinkedList<int>[] inputList, string outPath)
        {
            Console.WriteLine(inputList);
            List<int> vA = new List<int>(10);
            List<int> vB = new List<int>(10);

            for (int i = 0; i < inputList.Length; i++)
            {
                List<int> passed = inputList[i].ToList();
                for (int j = 0; j < passed.Count; j++)
                {
                    if (i + 1 <= passed[j])
                    {
                        vA.Add(i + 1);
                        vB.Add(passed[j]);
                    }
                }
            }

            using StreamWriter sw = new StreamWriter(outPath);

            sw.WriteLine(NVertex + " " + vA.Count);
            for (int i = 0; i < vA.Count; i++)
            {
                sw.Write(vA[i] + " " + vB[i]);
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Convert_From_EdgeList_To_AdjacencyList(string outPath)
        {
            using StreamWriter sw = new StreamWriter(outPath);

            sw.WriteLine(NVertex);
            for (int i = 1; i <= NVertex; i++)
            {
                if (EdgeList[i].Count > 0)
                {
                    foreach (var x in EdgeList[i])
                        sw.Write(x + " ");
                }
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
