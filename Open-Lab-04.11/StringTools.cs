using System;
using System.Collections.Generic;
using System.Linq;

namespace Open_Lab_04._11
{
    public class StringTools
    {
        public string AlphabetSoup(string str)
        {
            char[] pismena = str.ToCharArray();
            Array.Sort(pismena);
            string hotovo = string.Join("", pismena);
            return hotovo;         
        }
    }
}
