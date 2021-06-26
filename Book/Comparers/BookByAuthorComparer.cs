using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Book.Comparators
{
    public class BookByAuthorComparer : IComparer<Book>
    {
        public int Compare([AllowNull] Book lhs, [AllowNull] Book rhs) => (lhs, rhs) switch
        {
            _ when lhs is null && rhs is null => 0,
            _ when rhs is null => 1,
            _ when lhs is null => -1,
            _ => lhs.Author.Trim().Length - rhs.Author.Trim().Length,
        };

    }
}
