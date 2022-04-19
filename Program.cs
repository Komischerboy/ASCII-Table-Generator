using System;
using System.Collections.Generic;

namespace ASCII_Raw;

class Program
{
    static void Main(string[] args)
    {
        var lines = new List<string[]>
        {
            new string[] { " id ", " name ", " surename " },
            new string[] { " 1 ", " George ", " Gross " },
            new string[] { " 2 ", " Edie ", " Kirk " },
            new string[] { " 3 ", " Wilda ", " Simon " }
        };
                                                           
        var table = new ASCIITable(lines);
        Console.WriteLine(table.GetAsString());
    }
}

