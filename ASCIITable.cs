using System;
using System.Collections.Generic;
using System.Linq;

namespace ASCII_Raw;

public class ASCIITable
{
    private string[] rows;
    private List<string[]> lines;

    private int longestStringLength;

    public ASCIITable(List<string[]> table) {
        this.rows = table.First();
        table.Remove(this.rows);            
        this.lines = table;
    }

    public ASCIITable(string[] rows, List<string[]> lines)
    {
        this.rows = rows;
        this.lines = lines;
    }

    public string GetAsString()
    {
        string table;
        table = GenHeader() + "\n";
        table += GenContent() + "\n";
        return table;
    }

    private string GenContent()
    {

        string content = "";
        for (int i = 0; i < lines.Count; i++)
        {
            content += GenLine(lines[i]) + "\n";
        }

        return content + GenBodyFooter();
    }

    private string GenBodyFooter()
    {
        string footer = "└";
        foreach (var content in rows)
        {
            for (int i = 0; i < GenLongestStringLength(content); i++)
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
        string header = "";

        string top = "┌";
        string middle = "";
        string bottom = "├";

        foreach (var content in rows)
        {
            for (int i = 0; i < GenLongestStringLength(content); i++)
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
        string middle = "";
        middle += GenLine(rows);
        return middle;
    }

    private string GenLine(string[] contents)
    {
        string finalLine = "│";

        for (int i = 0; i < contents.Length; i++)
        {
            int longestStringLength = GenLongestStringLength(rows[i]); // contents.Length = rows.Length
            string content = contents[i];
            string line = content;

            float space = longestStringLength - content.ToCharArray().Length;
            bool isEven = space % 2 == 0;

            if (isEven)
            {
                for (int i2 = 0; i2 < space / 2; i2++)
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

    private int CalcLongest(int first, int second)
    {
        return (second < first ? first : second);
    }
}
