using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Ejemplos_Varios
{
    public class TwoSum
    {
        public int[] Solution(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    Console.WriteLine($"[{string.Join(", ", nums)}], {target}");
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            // No se necesita throw, ya que se asume que hay solución
            return new int[] { };
        }
    }
}
