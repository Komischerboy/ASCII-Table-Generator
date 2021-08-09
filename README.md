# ASCII-Table-Generator
With this class you can simply create ASCII-tables like:

```
┌────────────────────┬────────────────────┬────────────────────┐
│      serverid      │       roleid       │    permissions     │
├────────────────────┼────────────────────┼────────────────────┤
│ 829364130317336666 │ 848176387029991434 │   8749823749284    │
└────────────────────┴────────────────────┴────────────────────┘
```

# Usage
You can find this example in Program.cs

```cs
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
```
