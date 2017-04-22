//Prgram 4. CopyrightDesc class
//By: Chad Tracy
//this class uses ICompare interface to sort the list of library items in descending order




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    class CopyrightDesc : IComparer<LibraryItem>
    {
        //pre condition: none
        //post condition: sorts items by their copyright year in descending order
        public int Compare(LibraryItem c1, LibraryItem c2)
        {
            LibraryItem y1 = (LibraryItem)c1;
            LibraryItem y2 = (LibraryItem)c2;

            //uses if and else to sort. greater and less than signs are reversed because it's descending
            if (y1.CopyrightYear < y2.CopyrightYear)
                return 1;
            if (y1.CopyrightYear > y2.CopyrightYear)
                return -1;
            else
                return 0;

            
 
            
        }
    }
}
