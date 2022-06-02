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
var Lines = new List<string[]>
{
    new[] { " serverid ", " roleid ", " permissions " },
    new[] { " 829364130317336666 ", " 848176387029991434", " 8749823749284 " }
};
        
Console.WriteLine(new ASCIITable(Lines));
```
