using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Raw;

public class NewASCIITable
{
    private readonly List<string[]> table;

    public NewASCIITable(List<string[]> table) => this.table = table;

    public override string ToString() => GenTable();

    private string GenTable()
    {
        //get full length of table
        var TableLength = 0;
        table.ForEach(Line =>
        {
            var LongestDataLength = Line.Select(x => x.Length).Sum();
            if (TableLength < LongestDataLength) TableLength = LongestDataLength;
        });

        var Header = new StringBuilder();
        Header.Append("┌");
        Header.AppendLine();

        var ColumnSpacer = new List<int>();
        foreach (var Line in table)
        {
            Header.Append("│");

            for (var i = 0; i < Line.Length; i++)
            {
                var Data = Line[i];
                var ColumnList = table.Select(x => x[i]).ToList();

                //center datas
                var LongestColumnLength = ColumnList.OrderByDescending(x => x.Length).First().Length;
                if (ColumnSpacer.Count - 1 < Line.Length - 1) ColumnSpacer.Add(LongestColumnLength);
                var PadLeft = (LongestColumnLength - Data.Length) / 2 + Data.Length;

                Header.Append(Data.PadLeft(PadLeft).PadRight(LongestColumnLength));
                Header.Append("│");
            }

            Header.AppendLine();
            Header.Append(Line == table.Last() ? "└" : "├");

            ColumnSpacer.ForEach(length =>
            {
                Header.Append('─', length);
                Header.Append(Line == table.Last() ? "┴" : "┼");
            });

            Header.Length--; //remove last char=> because we want to use ┘ as end
            Header.Append(Line == table.Last() ? "┘" : "┤");
            Header.AppendLine();
        }

        for (var i = 0; i < ColumnSpacer.Count; i++)
        {
            var length = ColumnSpacer[i];
            Header.Insert(1, "─", length);
            if (i > 0) Header.Insert(length + 1, "┬");
        }

        Header.Insert(ColumnSpacer.Sum() + ColumnSpacer.Count, "┐");
        return Header.ToString();
    }
}