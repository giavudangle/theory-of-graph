using System;
using System.Collections.Generic;
using System.IO;

namespace LAB_TheoryofGraph
{
    class Program
    {
        /*============================Adjacency Matrix ===================================*/

        private static int nVertex;
        private static int nEdge;
        private static int[,] adjMatrix;

        public static void ReadDataGraph(string path)
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

        public static void FindAllDegree(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                int degree = 0;
                sw.WriteLine(nVertex);
                for (int i = 1; i <= nVertex; i++)
                {
                    degree = 0;
                    for (int j = 1; j <= nVertex; j++)
                    {
                        if (adjMatrix[i, j] == 1)
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
        public static void FindInAndOutDegree(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                int inDegree = 0, outDegree = 0;
                sw.WriteLine(nVertex);
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
                    sw.WriteLine(inDegree + " " + outDegree);
                }
            }
        }
        /*============================Adjacency List===================================*/
        public static LinkedList<int>[] adjList;
        public static void ReadAdjList(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                nVertex = int.Parse(reader.ReadLine());
                adjList = new LinkedList<int>[nVertex + 1];

                for (int i = 1; i <= nVertex; i++) adjList[i] = new LinkedList<int>();

                for (int i = 1; i <= nVertex; i++)
                {
                    string[] tokens = reader.ReadLine().Split();
                    for (int j = 1; j <= tokens.Length; j++)
                    {
                        if (tokens[j - 1] == "") 
                            continue;
                        adjList[i].AddLast(int.Parse(tokens[j - 1]));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void FindAllDegreeAdjList(string path)
        {
            using StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(nVertex);
            foreach (var x in adjList)
            {
                if (x == null) continue;
                sw.Write(x.Count + " ");
            }
            sw.Close();
        }

        /*============================ Edge List===================================*/
        public static int mEdge;
        public static List<Tuple<int, int>> edgeList;

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

        public static void FindAllDegreeEdgeList(string path)
        {
            using StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(nVertex);
            int[] counter = new int[1000];
            for (int i = 0; i < edgeList.Count; i++)
            {
                counter[edgeList[i].Item1]++;
                counter[edgeList[i].Item2]++;

            }


            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] > 0)
                {
                    sw.Write(counter[i] + " ");
                }
            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            ///*Bài 1. Bậc của đồ thị vô hướng*/
            string input = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB01\LAB_TheoryofGraph\DATA.txt";
            string output = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB01\LAB_TheoryofGraph\OUTPUT_DATA.txt";
            ReadDataGraph(input);
            FindAllDegree(output);
            ///*Bài 2. Bậc vào, bậc ra */
            FindInAndOutDegree(output);
            /*Bài 3. Danh sách kề*/
            ReadAdjList(input);
            FindAllDegreeAdjList(output);
            /*Bài 4. Danh sách cạnh */
            ReadDataEdgeList(input);
            FindAllDegreeEdgeList(output);




        }
    }
}
