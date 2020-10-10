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
        private LinkedList<int>[] edgeList;
        private LinkedList<int>[] adjList;

        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }
        public LinkedList<int>[] EdgeList { get => edgeList; set => edgeList = value; }
        public LinkedList<int>[] AdjList { get => adjList; set => adjList = value; }

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

        public void ReadData_AdjList_Contain_BlankLine(string path)
        {
            StreamReader sr = new StreamReader(path);
            NVertex = int.Parse(sr.ReadLine());
            AdjList = new LinkedList<int>[NVertex];

            for (int i = 0; i < NVertex; i++)
            {
                AdjList[i] = new LinkedList<int>();
                string tmp = sr.ReadLine();
                if (tmp.Trim().Length == 0)
                {
                    AdjList[i].AddLast(0);
                    continue;
                }
                string[] tokens = tmp.Split(' ');              
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

        private static List<int> vA_Temp = new List<int>(100);
        private static List<int> vB_Temp = new List<int>(100);

        public void Custom_Convert_AdjList_To_EdgeList(LinkedList<int>[] inputList)
        {
            for (int i = 0; i < inputList.Length; i++)
            {
                List<int> passed = inputList[i].ToList();
                for (int j = 0; j < passed.Count; j++)
                {

                    vA_Temp.Add(i + 1);
                    vB_Temp.Add(passed[j]);
                    
                }
            }
        }

        private static List<int>[] adj;
        private static List<int>[] res;

        public void TransposeGraph()
        {
            /*
            - we traverse the adjacency list and as we find a vertex v in the adjacency list of vertex u which indicates an edge from u to v in main graph,
            - we just add an edge from v to u in the transpose graph i.e.add u in the adjacency list of vertex v of the new graph.
            - Thus traversing lists of all vertices of main graph we can get the transpose graph. 
            - Thus the total time complexity of the algorithm is O(V + E) where V is number of vertices of graph and E is the number of edges of the graph.
            Note : It is simple to get the transpose of a graph which is stored in adjacency matrix format, you just need to get the transpose of that matrix.
                        int len = inputList.Length;

            */
            adj = new List<int>[NVertex+10];
            res = new List<int>[NVertex+10];

            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new List<int>();
                res[i] = new List<int>();
            }

            for (int i = 0; i < vA_Temp.Count; i++)
            {
                AddEdge(vA_Temp[i], vB_Temp[i], false);
            }

            getTranspose();
          

        }

        public void getTranspose()
        {
            // Traverse the graph and for each edge u, v  
            // in graph add the edge v, u in transpose 
            for (int i = 0; i < NVertex + 10; i++)
                for (int j = 0; j < adj[i].Count; j++)
                {
                    int x = adj[i][j];
                    if (x == 0) continue;
                    AddEdge(x, i, true);
                }
                    
        }


        public static void AddEdge(int u, int v, bool choice)
        {
            if (!choice)
                adj[u].Add(v);
            else
                res[u].Add(v);
        }

        public  void printGraph(string outPath)
        {
            using StreamWriter sw = new StreamWriter(outPath);
            sw.Write(NVertex);
            for ( int i = 0; i < NVertex+10; i++)
            {              
                for (int j = 0; j < res[i].Count; j++)
                {
                    if (res[i][j] == 0) continue;
                    sw.Write(res[i][j] + " ");
                }
                sw.WriteLine();
            }
        }
    }
}
