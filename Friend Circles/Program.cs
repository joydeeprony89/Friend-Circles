using System;

namespace Friend_Circles
{
    class Program
    {
        public int row;
        public int column;
        static void Main(string[] args)
        {
            var grid = new int[4][]
            {
                new int[4] { 1, 1, 0, 0 },
                new int[4] { 1, 1, 1, 0 },
                new int[4] { 0, 1, 1, 0 },
                new int[4] { 0, 0, 0, 1 }
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

            row = grid.Length;
            column = grid[0].Length;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // call the DFS helper method to recursively process all the adjacent cells.
                        Helper(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// This method will help us to perform DFS when we find 1 in a cell. It will traverse the adjacent cells where 1 is present and marked them as zero.
        /// execution of this recursive method will end when there are no more adjacent '1'.
        /// </summary>
        /// <param name="grid">input 2D array</param>
        /// <param name="i">row pos</param>
        /// <param name="j">column pos</param>
        void Helper(int[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= row || j >= column || grid[i][j] != 1) return;
            grid[i][j] = 0;
            Helper(grid, i + 1, j);
            Helper(grid, i - 1, j);
            Helper(grid, i, j + 1);
            Helper(grid, i, j - 1);
        }
    }
}
