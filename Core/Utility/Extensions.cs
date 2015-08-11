using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public static class Extensions
    {
        public static string CapitalizeFirstLetter(this string input)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
