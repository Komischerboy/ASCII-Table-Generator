using System;
using System.Collections.Generic;

namespace ASCII_Raw;

internal class Program
{
    private static void Main()
    {
        var lines = new List<string[]>
        {
            new[] { " serverid ", " name ", " surename " },
            new[] { " 1 ", " George ", " Gross " },
            new[] { " 2 ", " Edie ", " Kirk " },
            new[] { " 3 ", " Wilda ", " Simon " }
        };
                                                           
        var table = new NewASCIITable(lines);
        Console.WriteLine(table.ToString());
    }
}

