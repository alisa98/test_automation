using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Program
{
    class FordFulkerson
    {
        int V = 6;    //Number of vertices in graph


        bool BFS(int[][] rGraph, int s, int t, int[] parent) { 
           bool[] visited = new bool [V] ;
        for (int i = 0; i<V; ++i)
            visited[i] = false;
        
        LinkedList<int> queue = new LinkedList<int>();
        queue.AddLast(s);
        visited[s] = true;
        parent[s] = -1;

        
        while (queue.Count != 0)
        {
            int u = queue.Remove();

            for (int v = 0; v<V; v++)
            {
                if (visited[v] == false && rGraph[u][v] > 0)
                {
                    queue.AddLast(v);
                    parent[v] = u;
                    visited[v] = true;
                }
}
        }

  
        return (visited[t] == true);
        }

        int FordFukerson(int[,] graph, int s, int t)
        {
            int u, v;


            int[][] rGraph = new int[V][V];
 
        for (u = 0; u<V; u++)
            for (v = 0; v<V; v++)
                rGraph[u][v] = graph[u][v];
 
        int[] parent = new int[V];

        int max_flow = 0;  // There is no flow initially
 
      
        while (BFS(rGraph, s, t, parent))
        {
          
            int path_flow = int.MaxValue;
            for (v=t; v!=s; v=parent[v])
            {
                u = parent[v];
                path_flow = Math.Min(path_flow, rGraph[u][v]);
            }
 
            
            for (v=t; v != s; v=parent[v])
            {
                u = parent[v];
                rGraph[u][v] -= path_flow;
                rGraph[v][u] += path_flow;
            }

                max_flow += path_flow;
        }
       
        return max_flow;
        }
    
        public static void Main()
        {
        int[][] graph =new int[][] { {0, 16, 13, 0, 0, 0},
                                     {0, 0, 10, 12, 0, 0},
                                     {0, 4, 0, 0, 14, 0},
                                     {0, 0, 9, 0, 0, 20},
                                     {0, 0, 0, 7, 0, 4},
                                     {0, 0, 0, 0, 0, 0}
                                   };
            FordFulkerson m = new FordFulkerson();
            Console.Write("The maximum possible flow is " + m.FordFulkerson(graph,0,5));
            Console.ReadKey();
        }
    }
}



