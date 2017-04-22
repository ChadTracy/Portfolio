//Program 4. MultiSort class
//By: Chad Tracy
//This method is used to sort the Library items by type and then by title



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    class MultiSort : IComparer<LibraryItem>
    {
        //pre condition: none
        //post condition: items are sorted by type and then title
        public int Compare(LibraryItem i1, LibraryItem i2)
        {
            LibraryItem m1 = (LibraryItem)i1;
            LibraryItem m2 = (LibraryItem)i2;

            if (m1 == null && m2 == null) //if both values are null
                return 0;
            if (m1 == null) //if i1 is null
                return 1;
            if (m2 == null) //if i2 is null
                return -1;
            

            
            //sorts by type using gettype()
            int typeCompare = m1.GetType().FullName.CompareTo(m2.GetType().FullName);
            if (typeCompare != 0)
                return typeCompare;
            //sorts by title after type
            int titleCompare = m1.Title.CompareTo(m2.Title);
            if (titleCompare != 0)
                return titleCompare;

            else
                return 0;
            




        }
    }
}
