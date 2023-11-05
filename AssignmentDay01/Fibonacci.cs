using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Fibonacci
    {

        // Get a list with the Fibonacci Series given the num of terms parameter.
        public List<long> GetSeries(int num_terms)
        {
            // creating one empty resulting list
            var series = new List<long>();

            // looping from 0 to num_terms-1 ...
            for (int i = 0; i < num_terms; i++)
            {
                // if value 0 or 1, add the number
                if (i == 0 || i == 1) series.Add(i);
                // else, add the sum of two previous added numbers
                else series.Add(series[i-2]+series[i-1]);
            }

            // returning the resulting list
            return series;
        }

    }
}
