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
var lines = new List<string[]>
{
    new string[] { " id ", " name ", " surename " },
    new string[] { " 1 ", " George ", " Gross " },
    new string[] { " 2 ", " Edie ", " Kirk " },
    new string[] { " 3 ", " Wilda ", " Simon " }
};
                                                           
var table = new ASCIITable(lines);
Console.WriteLine(table.GetAsString());
```
