using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _874_WalkingRobotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //public class Solution
    //{
    //    public int RobotSim(int[] commands, int[][] obstacles)
    //    {
    //        // verification
    //        if (commands == null || obstacles == null || commands.Length == 0)
    //        {
    //            return 0;
    //        }

    //        // logic
    //        int distance = 0;
    //        int obsIndex = 0;
    //        int nextDirection = 0;
    //        int currentDirection = 0;
    //        int[] currentPoint = new int[2];

    //        for (int i = 0; i < commands.Length; i++)
    //        {
    //            if (commands[i] == -1 || commands[i] == -2)
    //            {
    //                nextDirection = commands[i];
    //                continue;
    //            }

    //            Compute(nextDirection, commands[i], obsIndex, obstacles, currentPoint, currentDirection);

    //            nextDirection = 0;
    //        }


    //        return distance;
    //    }

    //    private void Compute(int nextDirection, int command, int obsIndex, int[][] obstacles, int[] currentPoint, int currentDirection)
    //    {
    //        currentDirection = nextDirection;


    //    }
    //}

    public class Solution
    {
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };
            int x = 0, y = 0, di = 0;

            // Encode obstacles (x, y) as (x+30000) * (2^16) + (y+30000)
            HashSet<long> obstacleSet = new HashSet<long>();
            foreach (int[] obstacle in obstacles)
            {
                long ox = (long)obstacle[0] + 30000;
                long oy = (long)obstacle[1] + 30000;
                obstacleSet.Add((ox << 16) + oy);
            }


            int ans = 0;
            foreach (int cmd in commands)
            {
                if (cmd == -2)  //left
                    di = (di + 3) % 4;
                else if (cmd == -1)  //right
                    di = (di + 1) % 4;
                else
                {
                    for (int k = 0; k < cmd; ++k)
                    {
                        int nx = x + dx[di];
                        int ny = y + dy[di];
                        long code = (((long)nx + 30000) << 16) + ((long)ny + 30000);
                        if (!obstacleSet.Contains(code))
                        {
                            x = nx;
                            y = ny;
                            ans = Math.Max(ans, x * x + y * y);
                        }
                    }
                }
            }

            return ans;
        }
    }
}
