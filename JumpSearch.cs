using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithm
{
    internal class JumpSearch
    {
        public static int Perform(double searchValue, List<double> listToSearch)
        {
            int Quantity = (listToSearch.Count/5);
            int Counter = 0;
            while (Counter < listToSearch.Count)
            {
                if (listToSearch[Counter] == searchValue)
                {
                    return Counter;
                }
                else if (listToSearch[Counter] > searchValue)
                {
                    int Difference = Counter - Quantity;
                    for (int i =Counter-1; i > Difference; i--)
                    {
                        if (listToSearch[i] == searchValue)
                        {
                            return i;
                        }                      
                    }
                    return -1;
                }
                Counter += Quantity;
                if (Counter == listToSearch.Count)
                {
                    Counter--;
                }              
            }
            return -1;
        }
        public static int Perform(string searchValue, List<string> listToSearch)
        {
            int Quantity = (listToSearch.Count / 5);
            int Counter = 0;
            while (Counter < listToSearch.Count)
            {
                if (string.Compare(listToSearch[Counter], searchValue) == 0)
                {
                    return Counter;
                }
                else if (string.Compare(listToSearch[Counter], searchValue) > 0)
                {
                    int Difference = Counter - Quantity;
                    for (int i = Counter - 1; i > Difference; i--)
                    {
                        if (listToSearch[i] == searchValue)
                        {
                            return i;
                        }
                    }
                    return -1;
                }
                Counter += Quantity;
                if (Counter == listToSearch.Count)
                {
                    Counter--;
                }
            }
            return -1;
        }
    }
}
