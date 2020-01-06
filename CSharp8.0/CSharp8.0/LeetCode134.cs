using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode134
    {
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;

            int total_tank = 0;
            int curr_tank = 0;
            int starting_station = 0;
            for (int i = 0; i < n; ++i)
            {
                var p = gas[i] - cost[i];
                total_tank += p;
                curr_tank += p;
                // If one couldn't get here,
                if (curr_tank < 0)
                {
                    // Pick up the next station as the starting one.
                    starting_station = i + 1;
                    // Start with an empty tank.
                    curr_tank = 0;
                }
            }
            return total_tank >= 0 ? starting_station : -1;
        }
    }
}
