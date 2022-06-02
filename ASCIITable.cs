using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Table;

public class ASCIITable
{
    private readonly List<string[]> Lines;

    public ASCIITable(List<string[]> Lines) => this.Lines = Lines;

    public override string ToString() => GenTable();

    private string GenTable()
    {
        //get full length of table
        var TableLength = 0;
        Lines.ForEach(Line =>
        {
            var LongestDataLength = Line.Select(x => x.Length).Sum();
            if (TableLength < LongestDataLength) TableLength = LongestDataLength;
        });

        var Table = new StringBuilder();
        Table.Append("┌");
        Table.AppendLine();

        var ColumnSpacer = new List<int>();
        foreach (var Line in Lines)
        {
            Table.Append("│");

            for (var i = 0; i < Line.Length; i++)
            {
                var Data = Line[i];
                var ColumnList = Lines.Select(x => x[i]).ToList();

                //center datas
                var LongestColumnLength = ColumnList.OrderByDescending(x => x.Length).First().Length;
                if (ColumnSpacer.Count - 1 < Line.Length - 1) ColumnSpacer.Add(LongestColumnLength);
                var PadLeft = (LongestColumnLength - Data.Length) / 2 + Data.Length;

                Table.Append(Data.PadLeft(PadLeft).PadRight(LongestColumnLength));
                Table.Append("│");
            }

            Table.AppendLine();
            Table.Append(Line == Lines.Last() ? "└" : "├");

            ColumnSpacer.ForEach(length =>
            {
                Table.Append('─', length);
                Table.Append(Line == Lines.Last() ? "┴" : "┼");
            });

            Table.Length--; //remove last char => because we want to use ┘ as end
            Table.Append(Line == Lines.Last() ? "┘" : "┤");
            Table.AppendLine();
        }

        //Header
        var FullLength = 1;
        for (var i = 0; i < ColumnSpacer.Count; i++)
        {
            var SpacerPos = ColumnSpacer[i];
            Table.Insert(FullLength, "─",  SpacerPos);
            FullLength += SpacerPos;
            if (i != ColumnSpacer.Count - 1) Table.Insert(FullLength, "┬");
            FullLength++;
        }

        Table.Insert(ColumnSpacer.Sum() + ColumnSpacer.Count, "┐");
        return Table.ToString();
    }
}