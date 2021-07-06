using System;

namespace Friend_Circles
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[6][]
            {
                new int[6] { 1,1,0,0,0,0 },
                new int[6] { 1,1,0, 0, 0, 0 },
                new int[6] { 0,0,1, 1, 1, 0},
                new int[6] { 0, 0, 1, 1, 0, 0 },
                new int[6] { 0,0,1, 0, 1, 0},
                new int[6] { 0, 0, 0, 0, 0, 1 }
            };

            Program p = new Program();
            var op = p.CountFriendCircles(grid);
            Console.WriteLine($"No of friend cirlces are {op}");
        }

        int CountFriendCircles(int[][] grid)
        {
            // base condition
            if (grid == null || grid.Length == 0) return 0;

            int count = 0;
            // reference array to mark the already visited vertex.
            bool[] visited = new bool[grid.Length];
            // loop for each person
            for (int i = 0; i < grid.Length; i++)
            {
                // if the person not yet visisted.
                // perform DFS for that person.
                if (!visited[i])
                {
                    DFS(grid, visited, i);
                    count++;
                }
            }

            return count;
        }

        void DFS(int[][] grid, bool[] visited, int person)
        {
            // for the passed person you check with other persons if they are friend == 1
            for (int anotherPerson = 0; anotherPerson < grid.Length; anotherPerson++)
            {
                // person -> another person and another person is not yet visited
                if (grid[person][anotherPerson] == 1 && !visited[anotherPerson])
                {
                    // mark visited
                    visited[anotherPerson] = true;
                    // perfor DFS for new person, to find out the un connected elements
                    DFS(grid, visited, anotherPerson);
                }
            }
        }
    }
}
