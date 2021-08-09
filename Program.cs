using System.Collections.Generic;

namespace ASCII_Raw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> lines = new List<string[]>();
            string[] rows = { " id ", " name ", " surename " };
            string[] line1 = { " 1 ", " George ", " Gross " };
            string[] line2 = { " 2 ", " Edie ", " Kirk " };
            string[] line3 = { " 3 ", " Wilda ", " Simon " };
            lines.Add(rows);
            lines.Add(line1);
            lines.Add(line2);
            lines.Add(line3);

            ASCIITable table = new ASCIITable(lines);
            System.Console.WriteLine(table.GetAsString());
        }
    }
}
