using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Comparers
{
    public class BookByPagesComparer : IComparer<Book.Book>
    {
        public int Compare([AllowNull] Book.Book lhs, [AllowNull] Book.Book rhs) => (lhs, rhs) switch
        {
            _ when lhs is null && rhs is null => 0,
            _ when rhs is null => 1,
            _ when lhs is null => -1,
            _ => lhs.Pages - rhs.Pages,
        };
    }
}
