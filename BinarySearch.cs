using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithm
{
    internal class BinarySearch
    {
        public static int Perform(double searchValue, List<double> listToSearch)
        {
            int left = 0;
            int right = listToSearch.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (listToSearch[mid] == searchValue)
                {
                    return mid;
                }
                else if (listToSearch[mid] < searchValue)
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
        public static int Perform(string searchValue, List<string> listToSearch)
        {
            int left = 0;
            int right = listToSearch.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (string.Compare(listToSearch[mid],searchValue)==0)
                {
                    return mid;
                }
                else if (string.Compare(listToSearch[mid],searchValue)<0)
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
