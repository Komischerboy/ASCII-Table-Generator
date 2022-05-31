using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Raw;

public class NewASCIITable
{
    private readonly List<string[]> table;

    public NewASCIITable(List<string[]> table)
    {
        this.table = table;
    }

    public override string ToString() => GenHeader();

    private string GenHeader()
    {
        var Header = new StringBuilder();
        Header.Append("┌");

        //get full length of table
        var TableLength = 0;
        table.ForEach(Line =>
        {
            var LongestDataLength = Line.Select(x => x.Length).Sum();
            if (TableLength < LongestDataLength) TableLength = LongestDataLength;
        });
        TableLength += table.OrderByDescending(x => x.Length).First().Length + 1; //add space beause of │ seperators

        Header.Append('─', TableLength);
        Header.Append("┐");
        Header.AppendLine();

        foreach (var Line in table)
        {
            Header.Append("│");

            for (var i = 0; i < Line.Length; i++)
            {
                var Data = Line[i];
                var ColumnList = table.Select(x => x[i]).ToList();

                //center datas
                var LongestColumnLength = ColumnList.OrderByDescending(x => x.Length).First().Length;
                var PadLeft = (LongestColumnLength - Data.Length) / 2 + Data.Length;

                Header.Append(Data.PadLeft(PadLeft).PadRight(LongestColumnLength));
                Header.Append("│");
            }

            Header.AppendLine();
        }
        Header.Append("└");
        Header.Append('─', TableLength);
        Header.Append("┘");

        return Header.ToString();
    }
}