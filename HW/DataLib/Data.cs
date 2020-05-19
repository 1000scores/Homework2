using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class Data
    {
        public List<Element> input;

        public Data()
        {
            this.input = new List<Element>();
            ReadInput();
        }

        private void ReadInput()
        {
            string[] allLines = File.ReadAllLines("from_mos.csv", Encoding.GetEncoding(1251));
            char[] separator = { ';'};
            foreach (string line in allLines)
            {
                if (line == allLines[0]) continue;
                string[] temp = line.Split(separator);
                for(int i = 0; i < temp.Length; i++)
                {
                    string nw = "";
                    for(int j = 0; j < temp[i].Length; j++)
                    {
                        if((temp[i][j] < 'а' || temp[i][j] > 'я') 
                            && (temp[i][j] < 'А' || temp[i][j] > 'Я') && (temp[i][j] < '0' || temp[i][j] > '9')
                            && temp[i][j] != ' ' && temp[i][j] != '-')
                        {
                            continue;
                        } else
                        {
                            nw += temp[i][j];
                        }
                    }
                    temp[i] = nw;
                }
                Element cur = new Element(temp[1], int.Parse(temp[2]), temp[4], int.Parse(temp[5]));
                input.Add(cur);
            }
        }
    }
}
