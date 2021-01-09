using System;

namespace maze_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] m = Enter();
            MazeBFS maze = new MazeBFS(m);
            maze.PathFind();
            Console.WriteLine(maze);
        }
       
        public static string[,] Enter()
        {
            Console.WriteLine("* - wall, S - start point, . - you can go, if the point is on the far wall then it may be an exit");

            int L = int.Parse(Console.ReadLine());
           
            string[,] Maze = new string[L,L];
            for (int i = 0; i < L; i++)
            {
                string str = Convert.ToString(Console.ReadLine());
                char[] arr = str.ToCharArray();
                for (int j = 0; j < L; j++)
                {
                    Maze[i,j] = arr[j].ToString();
                }
            }
            return Maze;
        }
    }
    class MazeBFS
    {
        private string[,] maze;
      
        public MazeBFS(string[,] maze)
        {
            this.maze = maze;
        }
       
        public void PathFind()
        {
            string[,] Maze = maze;
            int startX = 0;
            int startY = 0;
            int counter = 0;
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    if (Maze[i, j] == "S")
                    {
                        startX = i;
                        startY = j;
                        FindWay(Maze, startX, startY, counter);
                    }
                   
                }
            }
        }
        void FindWay(string[,] Maze, int startX, int startY, int counter)
        {
            try
            {
                if (Maze[startX + 1, startY] == ".")
                {
                    int nextX = startX + 1;
                    int nextY = startY;
                    counter++;
                    Maze[startX + 1, startY] = counter.ToString();

                    FindWay(Maze, nextX, nextY, counter);
                }
                if (Maze[startX - 1, startY] == ".")
                {
                    int nextX = startX - 1;
                    int nextY = startY;
                    counter++;
                    Maze[startX - 1, startY] = counter.ToString();
                    FindWay(Maze, nextX, nextY, counter);
                }
                if (Maze[startX, startY - 1] == ".")
                {
                    int nextX = startX;
                    int nextY = startY - 1;
                    counter++;
                    Maze[startX, startY - 1] = counter.ToString();
                    FindWay(Maze, nextX, nextY, counter);
                }
                if (Maze[startX, startY + 1] == ".")
                {
                    int nextX = startX;
                    int nextY = startY + 1;
                    counter++;
                    Maze[startX, startY + 1] = counter.ToString();
                    FindWay(Maze, nextX, nextY, counter);
                }
            }
            catch (Exception e)
            {
                
            }
            
        }
        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < maze.GetLength(0); i++)
            {

                for (int j = 0; j < maze.GetLength(1); j++)
                {

                    str += maze[i, j];
                    str += " ";
                }
                str += Environment.NewLine;
            }
            return str;
        }
    }
}
