using System;

namespace LAB04
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"C:\Users\Admin\source\repos\LAB04\LAB04\INPUT.txt";
            string output = @"C:\Users\Admin\source\repos\LAB04\LAB04\OUTPUT.txt";

            GraphComponent graphComponent = new GraphComponent();

            graphComponent.ReadGraph(input);
            graphComponent.PrintAllConnectedComponents(output);

        }
    }
}
