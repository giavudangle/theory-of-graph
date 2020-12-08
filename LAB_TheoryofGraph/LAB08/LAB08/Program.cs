using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB08
{
    class Program
    {
        static int[,] direction = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        static int m, n, x, y;
        static int[,] a;
        static bool[,] visited;
        static int[,] cost;
        
        const int INF = (int)1e9;

        // FloyWarshall Update Varriables
        static int[,] pre;
        static int[,] dist;

        // Circle Update Varriables
        static int s, t;
        static List<Tuple<int, int,int>> rawData;
        static LinkedList<Tuple<int, double>>[] adj;
        static bool[] processed;
        static double[] distances;



        // Read Graph
        public static void ReadGraph()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            x = int.Parse(tokens[2]);
            y = int.Parse(tokens[3]);

            a = new int[n + 1, m + 1];
            for(int i = 1; i <= n; i++)
            {
                tokens = Console.ReadLine().Split(' ');
                for(int j = 1; j <= m; j++)
                {
                    a[i, j] = int.Parse(tokens[j - 1]);
                }
            }
         
        }

        // Initilize Resources
        public static void InitializeResources()
        {
            visited = new bool[n + 1, m + 1];
            cost = new int[n + 1, m + 1];
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= m; j++)
                {
                    visited[i, j] = false;
                    cost[i, j] = INF;
                }
            }
        }

        // Check isOutline
        public static bool isOutline(int a, int b)
        {
            if (a - 1 == 0 || b - 1 == 0 | a == n | b == m)
                return true;
            return false;
        }

        // Dijsktra Apply
        public static int Dijsktra(int xPoint,int yPoint)
        {
            InitializeResources();
            cost[xPoint, yPoint] = a[xPoint, yPoint];
            SortedSet<Tuple<int, int, int>> sortedSet = new SortedSet<Tuple<int, int, int>>();
            
            // Priority for min cost (to compare in Dijsktra Algorithm )
            Tuple<int, int, int> t = new Tuple<int, int, int>(cost[xPoint, yPoint], xPoint, yPoint);
            sortedSet.Add(t); // Add the first elements

            while (sortedSet.Count != 0)
            {
                Tuple<int, int, int> minValue = sortedSet.Min;

                sortedSet.Remove(minValue);

                if (visited[minValue.Item2, minValue.Item3])
                    continue;

                visited[minValue.Item2, minValue.Item3] = true;

                //Kiểm tra nếu điểm (x,y) là điểm ở biên, trả về kết quả. Kết thúc thuật toán
                if (isOutline(minValue.Item2, minValue.Item3))
                    return cost[minValue.Item2, minValue.Item3];

                //Duyệt các điểm (u,v) kề với điểm (x,y), sử dụng mảng direction
                for (int i = 0; i <= 3; i++)
                {
                    int u = minValue.Item2 + direction[i, 0];
                    int v = minValue.Item3 + direction[i, 1];          

                    //Với mỗi điểm (u,v) chưa viếng thăm và có chi phí chưa tối ưu                 
                    if (!visited[u, v] && (cost[u,v] > (cost[minValue.Item2,minValue.Item3] +a[u,v])))
                    {
                        //Cập nhật lại chi phí tại điểm (u,v)
                        cost[u, v] = cost[minValue.Item2, minValue.Item3] + a[u,v];                 
                        //Thêm (u,v) và trong SortedSet
                        sortedSet.Add(new Tuple<int, int, int>(cost[u, v], u, v)); 
                         
                    }
                }            
            }
            return 0;
        }


        /*====================================================================================*/
        public static void ReadData()
        {
            n = int.Parse(Console.ReadLine());
            a = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                for (int j = 0; j < tokens.Length; j++)
                {
                    a[i, j] = int.Parse(tokens[j]);
                }
            }
        }

        public static void FloyWarshallFunction()
        {
            dist = new int[n, n];
            pre = new int[n, n];

            // Initialize 
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        dist[i, j] = 0;
                    if (a[i, j] > 0)
                    {
                        dist[i, j] = a[i, j];
                        pre[i, j] = i;
                    }
                    else
                    {
                        dist[i, j] = INF;
                        pre[i, j] = i;
                    }
                }
            }

            // Loop function to find dist
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, j] > (dist[i, k] + dist[k, j]))
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            pre[i, j] = pre[i, k];
                        }
                    }
                }
            }


            // i == j cost is zero
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j)
                        dist[i, j] = 0;
            Console.WriteLine();

            List<(int, int)> res = new List<(int, int)>();

     
            for (int i = 0; i < n; i++)
            {
                int _currentMax = 0;
                for (int j = 0; j < n; j++)
                {
                   if(dist[i,j] > _currentMax)
                    {
                        _currentMax = dist[i, j];
                    }
                }
                res.Add((_currentMax, i));            
            }
            (int, int) result = res.OrderBy(item => item.Item1).First();
            Console.WriteLine(result.Item2 + 1); // My implementation start from zero :))
            Console.WriteLine(result.Item1);
        }

        /*====================================================================================*/


        public static void ReadCicleData()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            n = int.Parse(tokens[0]);
            s = int.Parse(tokens[1]);
            t = int.Parse(tokens[2]);

            rawData = new List<Tuple<int, int, int>>(n+1);

            for(int i = 1; i <=n; i++)
            {
                tokens = Console.ReadLine().Split(' ');

                int xi = int.Parse(tokens[0]);
                int yi = int.Parse(tokens[1]);
                int ri = int.Parse(tokens[2]);

                rawData.Add(new Tuple<int, int, int>(xi, yi, ri));
            }
            Console.WriteLine(rawData);
        }

        public static void ConvertData()
        {
            adj = new LinkedList<Tuple<int, double>>[n+1];

            for(int i = 1; i <= n; i++)
            {
                adj[i] = new LinkedList<Tuple<int, double>>();
            }

            for(int i = 1; i <= n; i++)
            {
                // Lấy đường tròn i
                Tuple<int, int,int> firstCircle = rawData[i-1];
                int xFirstCircle = firstCircle.Item1;
                int yFirstCircle = firstCircle.Item2;
                for(int j = i+1; j <= n; j++)
                {
                    // Lấy đường tròn j
                    Tuple<int, int, int> secondCircle = rawData[j-1];
                    int xSecondCircle = secondCircle.Item1;
                    int ySecondCircle = secondCircle.Item2;

                    //Tìm khoảng cách giữa 2 đường tròn
                    double d = Math.Sqrt(Math.Pow(xFirstCircle - xSecondCircle, 2) + Math.Pow(yFirstCircle - ySecondCircle, 2));
                    
                    // Đồ thị vô hướng thêm vào cả 2 đỉnh danh sách kề
                    adj[i].AddLast(new Tuple<int, double>(j, d));
                    adj[j].AddLast(new Tuple<int, double>(i, d));
    
                }
            }
            Console.WriteLine(adj);
        }

        static double DijsktraForCircle(int start)
        {
            distances = new double[n + 1];
            processed = new bool[n + 1];

            for(int i = 0; i < n; i++)
            {
                distances[i] = INF;
                processed[i] = false;
            }

            distances[start] = 0;

            for(int k = 1; k <= n; k++)
            {
                // Lấy min
                int a = -1;
                for(int i= 1; i <= n; i++) 
                    if (processed[i] == false && (a == -1 || distances[a] > distances[i]))
                        a = i;
                if (distances[a] == INF) break;
                processed[a] = true;

                // So sánh chi phí
                foreach(var edge in adj[a])
                {
                    int b = edge.Item1;
                    double w = edge.Item2;
                    if(distances[b] > distances[a] + w)
                    {
                        distances[b] = distances[a] + w;
                    }
                }
               
            }
            return distances[t]; // Min cost at t ( FROM S -> T)
        }


        static void Main(string[] args)
        {
            /*
             * Bài 1. Đi ra biên
            Cho bảng kích thước 𝑛 × 𝑚 (𝑛, 𝑚 ≤ 1000) các số tự nhiên. Từ một ô có thể di chuyển sang một ô kề cạnh
            với nó, nhưng không được đi ra ngoài bảng. Hãy tìm một cách đi từ ô (𝑥, 𝑦) cho trước đến một ô biên sao
            cho tổng số của các ô đi qua là nhỏ nhất.
             * 
             */
            //ReadGraph();
            //int result = Dijsktra(x, y);
            //Console.WriteLine(result);

            /* 
             * Bài 2. Chọn thành phố để tổ chức họp
            Có 𝑛 (𝑛 ≤ 100) thành phố được đánh số từ 1 đến 𝑛. Khoảng cách giữa hai thành phố 𝑖 và 𝑗 là 𝑎𝑖𝑗. Người
            ta muốn tổ chức một cuộc họp quy tụ 𝑛 lãnh đạo thành phố. Hãy tìm một thành phố để tổ chức cuộc họp sao
            cho khoảng cách của người đi xa nhất là nhỏ nhất có thể.
             Dòng đầu là thành phố đăng cai tổ chức.
             Dòng thứ hai, thời gian của người phải đi xa nhất.
             */
            //ReadData();
            //FloyWarshallFunction();


            /* 
            * Bài 3. Đường tròn
           Trên mặt phẳng cho 𝑛 đường tròn, các đường tròn được đánh số từ 1 đến 𝑛. Đường tròn thứ 𝑖 được cho bởi
           bộ ba số thực (𝑥𝑖, 𝑦𝑖 𝑟𝑖), trong đó (𝑥𝑖, 𝑦𝑖) là toạ độ của tâm đường tròn và 𝑟𝑖
           là bán kính của đường tròn. Một đối tượng nằm trong đường tròn có thể di chuyển tự do trong đường tròn đó với chi phí bằng 0. Nhưng để
           di chuyển đối tượng đến vị trí ngoài đường tròn thì trước tiên phải di chuyển đường tròn đang chứa đối
           tượng đến đường tròn nào đó chứa điểm cần đến. Chi phí di chuyển giữa hai đường tròn bằng khoảng cách
           giữa chúng. Một đối tượng đang ở trong đường tròn 𝑠, hãy tìm phương án di chuyển đối tượng đến đường
           tròn 𝑡 sao cho tốn chi phí ít nhất.
            ***/

            //ReadCicleData();
            //ConvertData();
            //double res  = DijsktraForCircle(s);
            //Console.WriteLine("{0:F2}", res);



        }
    }
}
