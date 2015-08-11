using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public static class PopulationCenter
    {
        public static int GetPopulation(int maxPopulation, double modifier)
        {
            return Convert.ToInt32((Convert.ToDouble(maxPopulation) * modifier));
        }
    }
}
