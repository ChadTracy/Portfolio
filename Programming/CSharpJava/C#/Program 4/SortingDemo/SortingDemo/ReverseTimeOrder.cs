// File: ReverseTimeOrder.cs
// By: Andrew L. Wright
// This class provides an IComparer for the Time2 class
// that orders the objects in reverse natural order.

using System;
using System.Collections.Generic;
using System.Text;

namespace SortingDemo
{
    public class ReverseTimeOrder : IComparer<Time2>
    {
        // Precondition:  None
        // Postcondition: Reverses natural time order, so
        //                When t1 < t2, method returns positive #
        //                When t1 == t2, method returns zero
        //                When t1 > t2, method returns negative #
        public int Compare(Time2 t1, Time2 t2)
        {
            // Implements correct handling of null values (in .NET, null less than anything)
            if (t1 == null && t2 == null) // Both null?
                return 0;

            if (t1 == null) // only t1 is null?
                return -1;

            if (t2 == null) // only t2 is null?
                return 1;

            return t2.CompareTo(t1); // Reverses natural order
        }
    }
}
