using System;
using System.Collections.Generic;

namespace LAB03
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Dotnet_Zone\LAB03\LAB03\DATA.txt";
            string outPath = @"D:\Dotnet_Zone\LAB03\LAB03\OUTPUT.txt";
            AdjacencyList adjacencyList = new AdjacencyList();
            //adjacencyList.ReadGraph(path);
            //adjacencyList.BFS_Source(adjacencyList.X);
            //adjacencyList.CountInterconnectionVertex(outPath);
            //adjacencyList.Custom_BFS()
            adjacencyList.CustomReadData(path);
            adjacencyList.PrintAllPaths(adjacencyList.X, adjacencyList.Y);
            adjacencyList.writeFileAllPaths(outPath);
        }
    }
}
