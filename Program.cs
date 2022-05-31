using System;
using System.Collections.Generic;

namespace ASCII_Table;

internal class Program
{
    private static void Main()
    {
        var Lines = new List<string[]>
        {
            new[] { " serverid ", " roleid ", " permissions " },
            new[] { " 829364130317336666 ", " Geo848176387029991434", " 8749823749284 " }
        };
        
        Console.WriteLine(new ASCIITable(Lines));
    }
}

