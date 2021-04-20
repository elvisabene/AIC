using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInformer
{
    public static class Validator
    {
        public static string CheckString(string str)
        {
            if (str == null)
            {
                return new string(' ', 1);
            }    
            else
            {
                return str;
            }
        }
    }
}
