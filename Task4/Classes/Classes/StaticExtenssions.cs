using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Class to show how static extenssiong work
    /// </summary>
    public static class StaticExtenssions
    {
        /// <summary>
        /// Simple bool parse method
        /// </summary>
        /// <param name="value">Value to parse</param>
        /// <returns>Bool value of parsing</returns>
        public static bool ToBool(this int value)
        {
            if (value == 0) return false;
            else return true;
        }
    }
}
