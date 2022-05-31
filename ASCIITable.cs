using System;
using System.Collections.Generic;
using System.Linq;

namespace ASCII_Raw;

public class ASCIITable
{
    private readonly string[] rows;
    private readonly List<string[]> lines;

    private int longestStringLength;

    public ASCIITable(List<string[]> table) {
        rows = table.First();
        table.Remove(rows);            
        lines = table;
    }

    public ASCIITable(string[] rows, List<string[]> lines)
    {
        this.rows = rows;
        this.lines = lines;
    }

    public string GetAsString()
    {
        var table = GenHeader() + "\n";
        table += GenContent() + "\n";
        return table;
    }

    private string GenContent()
    {
        var content = lines.Aggregate("", (current, t) => current + (GenLine(t) + "\n"));
        return content + GenBodyFooter();
    }

    private string GenBodyFooter()
    {
        var footer = "└";
        foreach (var content in rows)
        {
            for (var i = 0; i < GenLongestStringLength(content); i++)
            {
                footer += "─";
            }
            footer += "┴";
        }
        footer = footer.Remove(footer.ToCharArray().Length - 1) + "┘";
        return footer;
    }

    private string GenHeader()
    {
        var header = "";

        var top = "┌";
        var middle = "";
        var bottom = "├";

        foreach (var content in rows)
        {
            for (var i = 0; i < GenLongestStringLength(content); i++)
            {
                top += "─";
                bottom += "─";
            }
            top += "┬";
            bottom += "┼";
        }
        top = top.Remove(top.ToCharArray().Length - 1) + "┐";
        bottom = bottom.Remove(bottom.ToCharArray().Length - 1) + "┤";
        middle = GenMiddle();


        header = top + "\n" + middle + "\n" + bottom;

        return header;
    }

    private string GenMiddle()
    {
        var middle = "";
        middle += GenLine(rows);
        return middle;
    }

    private string GenLine(string[] contents)
    {
        var finalLine = "│";

        for (var i = 0; i < contents.Length; i++)
        {
            var longestStringLength = GenLongestStringLength(rows[i]); // contents.Length = rows.Length
            var content = contents[i];
            var line = content;

            float space = longestStringLength - content.ToCharArray().Length;
            var isEven = space % 2 == 0;

            if (isEven)
            {
                for (var i2 = 0; i2 < space / 2; i2++)
                {
                    line = line.Insert(0, " ");
                    line += " ";
                }
            }
            else
            {
                for (int i2 = 0; i2 < Math.Floor(space / 2); i2++)
                {
                    line = line.Insert(0, " ");
                }
                for (int i3 = 0; i3 < Math.Floor(space / 2) + 1; i3++)
                {
                    line += " ";
                }
            }

            line += "│";
            finalLine += line;
        }

        return finalLine;
    }

    private int GenLongestStringLength(string content)
    {
        List<string> LineList = new List<string>();
        foreach (var line in lines)
        {
            var longestline = line.OrderByDescending(s => s.Length).First();
            LineList.Add(longestline);
        }
        string[] longest = LineList.ToArray();

        longestStringLength = CalcLongest(content.ToCharArray().Length, longest.OrderByDescending(s => s.Length).First().ToCharArray().Length);
        return longestStringLength;
    }

    private int CalcLongest(int first, int second) => (second < first ? first : second);
    
}
