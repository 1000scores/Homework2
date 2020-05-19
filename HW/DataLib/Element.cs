using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class Element
    {
        public string name;
        public int year;
        public string month;
        public int numberOfCalls;

        public Element(string name, int year, string month, int numberOfCalls)
        {
            this.name = name;
            this.year = year;
            this.month = month;
            this.numberOfCalls = numberOfCalls;
        }

    }
}
