using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithm
{
    internal class BinarySearch
    {
        public static int Perform(double searchValue, List<double> listToSeach)
        {
            int left = 0;
            int right = listToSeach.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (listToSeach[mid] == searchValue)
                {
                    return mid;
                }
                else if (listToSeach[mid] < searchValue)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;

        }
    }
}
