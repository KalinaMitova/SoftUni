using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Sorter
{
    public static CustomList<T> Sort<T>(CustomList<T> list)
        where T : IComparable<T>
    {
        return new CustomList<T>(list.OrderBy(e => e).ToList());
    }
}