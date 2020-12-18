using System;
using System.Collections.Generic;
using System.IO;

namespace LAB02
{
    class Program
    {
        /*============================ Convert EdgeList to Adj List===================================*/
        public static int nVertex, mEdge;
        public static List<Tuple<int, int>> edgeList;
        public static LinkedList<int>[] adjList;

        public static void ReadDataEdgeList(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string[] tokens = reader.ReadLine().Split();
                nVertex = int.Parse(tokens[0]);
                mEdge = int.Parse(tokens[1]);
                edgeList = new List<Tuple<int, int>>();

                for (int i = 1; i <= mEdge; i++)
                {
                    tokens = reader.ReadLine().Split();
                    int u = int.Parse(tokens[0]);
                    int v = int.Parse(tokens[1]);
                    edgeList.Add(new Tuple<int, int>(u, v));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static LinkedList<int>[] ConvertFromEdgeListToAdjList()
        {
            adjList = new LinkedList<int>[nVertex + 1];
            for (int i = 1; i <= nVertex; i++) adjList[i] = new LinkedList<int>();
            foreach (Tuple<int, int> it in edgeList)
            {
                int u = it.Item1;
                int v = it.Item2;
                adjList[u].AddLast(v);
                adjList[v].AddLast(u);
            }
            return adjList;
        }


        public static void PrintEdgeListToAdjList(LinkedList<int>[] data, string outPath)
        {
            using StreamWriter sw = new StreamWriter(outPath);
            sw.WriteLine(nVertex);
            for (int i = 1; i <= nVertex; i++)
            {
                foreach (var it in data[i])
                    sw.Write(it + " ");
                sw.WriteLine();
            }
        }



        /*============================ Convert Adj List to Edge List===================================*/
        public static void ReadAdjList(string path)
        {

            StreamReader reader = new StreamReader(path);
            nVertex = int.Parse(reader.ReadLine());
            adjList = new LinkedList<int>[nVertex + 1];

            for (int i = 1; i <= nVertex; i++) adjList[i] = new LinkedList<int>();

            for (int i = 1; i <= nVertex; i++)
            {
                string[] tokens = reader.ReadLine().Split();
                if (tokens.Length == 0) continue;
                for (int j = 1; j <= tokens.Length; j++)
                {
                    if (tokens[j - 1] == "")
                        continue;
                    adjList[i].AddLast(int.Parse(tokens[j - 1]));
                }
            }
            reader.Close();
        }


        public static List<Tuple<int, int>> ConvertFromAdjListToEdgeList()
        {
            edgeList = new List<Tuple<int, int>>();
            for (int i = 1; i < adjList.Length; i++)
                foreach (int item in adjList[i])
                    if (i < item)
                        edgeList.Add(new Tuple<int, int>(i, item));
            return edgeList;
        }

        public static void PrintAdjListToEdgeList(List<Tuple<int, int>> data, string outPath)
        {
            using StreamWriter sw = new StreamWriter(outPath);
            sw.WriteLine(nVertex + " " + data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                sw.Write(data[i].Item1 + " " + data[i].Item2);
                sw.WriteLine();
            }
        }

        /*============================ BON CHUA ===================================*/
        public static int[,] adjMatrix;
        public static void ReadDataAdjMatrix(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                nVertex = int.Parse(reader.ReadLine());
                adjMatrix = new int[nVertex + 1, nVertex + 1];
                for (int i = 1; i <= nVertex; i++)
                {
                    string[] tokens = reader.ReadLine().Split();
                    for (int j = 1; j <= nVertex; j++)
                        adjMatrix[i, j] = int.Parse(tokens[j - 1]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void CheckStorage(int[,] inputMatrix, string path)
        {
            int inDegree = 0, outDegree = 0;
            List<int> listVertex = new List<int>();
            int k = 0;
            for (int i = 1; i <= nVertex; i++)
            {
                inDegree = 0;
                outDegree = 0;
                for (int j = 1; j <= nVertex; j++)
                {
                    if (adjMatrix[j, i] > 0)
                        inDegree++;
                    if (adjMatrix[i, j] > 0)
                        outDegree++;
                }
                if (inDegree > 0 && outDegree == 0)
                {
                    k++;
                    listVertex.Add(i);
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
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

        /*============================ TRANSPOSE===================================*/
        private static List<int>[] adj;
        private static List<int>[] res;

        public static List<Tuple<int, int>> ConvertFromAdjListToEdgeListDirectedGraph()
        {
            edgeList = new List<Tuple<int, int>>();
            for (int i = 1; i < adjList.Length; i++)
                foreach (int item in adjList[i])                
                        edgeList.Add(new Tuple<int, int>(i, item));
            return edgeList;
        }



        public static void TransposeGraph()
        {
            /*
            - we traverse the adjacency list and as we find a vertex v in the adjacency list of vertex u which indicates an edge from u to v in main graph,
            - we just add an edge from v to u in the transpose graph i.e.add u in the adjacency list of vertex v of the new graph.
            - Thus traversing lists of all vertices of main graph we can get the transpose graph. 
            - Thus the total time complexity of the algorithm is O(V + E) where V is number of vertices of graph and E is the number of edges of the graph.
            Note : It is simple to get the transpose of a graph which is stored in adjacency matrix format, you just need to get the transpose of that matrix.
                        int len = inputList.Length; */

            adj = new List<int>[nVertex + 1];
            res = new List<int>[nVertex + 1];

            for(int i = 1; i <= nVertex; i++)
            {
                adj[i] = new List<int>();
                res[i] = new List<int>();
            }

            for (int i = 1; i <= edgeList.Count; i++)
                ShouldChoice(edgeList[i - 1].Item1, edgeList[i - 1].Item2,false);
            getTranspose();
        }

        public static void ShouldChoice(int u, int v, bool choice)
        {
            if (!choice)
                adj[u].Add(v);
            else
                res[u].Add(v);
        }

        public static void getTranspose()
        {
            // Traverse the graph and for each edge u, v  
            // in graph add the edge v, u in transpose 
            for (int i = 1; i <= nVertex ; i++)
                for (int j = 0; j < adj[i].Count; j++)
                {
                    int x = adj[i][j];
                    if (x == 0) continue;
                    ShouldChoice(x, i, true);
                }

        }

        public static void printTransposeGraph(string outPath)
        {
            using StreamWriter sw = new StreamWriter(outPath);
            sw.WriteLine(nVertex);
            for (int i = 1; i <= nVertex ; i++)
            {
                for (int j = 0; j < res[i].Count; j++)
                {
                    if (res[i][j] == 0) continue;
                    sw.Write(res[i][j] + " ");
                }
                sw.WriteLine();
            }
        }

        /*============================ TOTALCOST EDGES===================================*/
        public static List<Tuple<int, int, int>> edgeListHaveCosts;
        public static void ReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] tokens = sr.ReadLine().Split(' ');
                nVertex = int.Parse(tokens[0]);
                mEdge = int.Parse(tokens[1]);
                edgeListHaveCosts = new List<Tuple<int, int, int>>();
                for (int i = 0; i < mEdge; i++)
                {
                    tokens = sr.ReadLine().Split(' ');
                    if (tokens.Length == 0) continue;
                    Tuple<int, int, int> temp =
                        new Tuple<int, int, int>(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
                    edgeListHaveCosts.Add(temp);

                }
            }
        }

        public static double ProcessAverageEdge()
        {
            int sum = 0;
            foreach (Tuple<int, int, int> it in edgeListHaveCosts)
            {
                sum += it.Item3;
            }
            return sum * 1.0 / mEdge;
        }

        public static List<Tuple<int, int, int>> GetListMaxCost()
        {
            List<Tuple<int, int, int>> res = new List<Tuple<int, int, int>>();
            Tuple<int, int, int> maxTuple = edgeListHaveCosts[0];

            foreach (Tuple<int, int, int> it in edgeListHaveCosts)
                if (it.Item3 > maxTuple.Item3)
                    maxTuple = it;
            foreach (Tuple<int, int, int> it in edgeListHaveCosts)
                if (it.Item3 == maxTuple.Item3)
                    res.Add(it);
            return res;
        }

        public static void PrintResult(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(ProcessAverageEdge());
                sw.WriteLine(GetListMaxCost().Count);
                foreach (Tuple<int, int, int> it in GetListMaxCost())
                    sw.WriteLine(it.Item1 + " " + it.Item2 + " " + it.Item3);
            }

        }
        /* BÀI TẬP LÀM THÊM*/

        
        
        public static void ConvertFromAdjMatrixToAdjList(string path)
        {
            adjList = new LinkedList<int>[nVertex + 1];
            for (int i = 1; i <= nVertex; i++) adjList[i] = new LinkedList<int>();
            for(int i = 1; i <= nVertex; i++)
            {
                for(int j = 1; j <= nVertex; j++)
                {
                    if(adjMatrix[i,j] > 0)
                    {
                        adjList[i].AddLast(j);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(nVertex);
                for (int i = 1; i <= nVertex; i++)
                {
                    foreach (int x in adjList[i])
                        sw.Write(x + " ");
                    sw.WriteLine();
                }
            }
           
            
        }

        public static void ConvertFromAdjMatrixToEdgeList(string path )
        {
            edgeList = new List<Tuple<int,int>>();
            for (int i = 1; i <= nVertex; i++)
            {
                for (int j = 1; j <= nVertex; j++)
                {
                    if (adjMatrix[i, j] > 0 && i<j)
                    {
                        edgeList.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(nVertex);
                for (int i = 0; i <edgeList.Count; i++)
                {               
                    sw.Write(edgeList[i].Item1 + " " + edgeList[i].Item2);
                    sw.WriteLine();
                }
               
            }

        }


        static void Main(string[] args)
        {
            string inpPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\INPUT.txt";
            string outPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\OUTPUT.txt";


            /* Bài 1. Chuyển danh sách cạnh sang danh sách kề */
            //ReadDataEdgeList(inpPath);
            //PrintEdgeListToAdjList(ConvertFromEdgeListToAdjList(),outPath);


            /* Bài 2. Chuyển danh sách kề sang danh sách cạnh*/
            //ReadAdjList(inpPath);
            //PrintAdjListToEdgeList(ConvertFromAdjListToEdgeList(), outPath);
            /* Bài 3.  Bồn chứa */
            //ReadDataAdjMatrix(inpPath);
            //CheckStorage(adjMatrix, outPath);
            /* Bài 4. Đồ thị chuyển vị */
            //ReadAdjList(inpPath);
            //ConvertFromAdjListToEdgeListDirectedGraph();
            //TransposeGraph();
            //printTransposeGraph(outPath);


            /* Bài 5. Độ dài trung bình của cạnh*/
            //ReadData(inpPath);
            //PrintResult(outPath);


            /* BÀI TẬP LÀM THÊM*/

            /*Bài 1. Chuyển ma trận kề sang danh sách kề*/
            //ReadDataAdjMatrix(inpPath);
            //ConvertFromAdjMatrixToAdjList(outPath);

            /*Bài 2. Chuyển ma trận kề sang danh sách cạnh*/
            ReadDataAdjMatrix(inpPath);

            ConvertFromAdjMatrixToEdgeList(outPath);

        }
    }
}
