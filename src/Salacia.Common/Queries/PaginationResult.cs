using System.Collections.Generic;

namespace Salacia.Common.Queries
{
    public class PaginationResult<TResult>
    {
        public ICollection<TResult> Items { get; set; }

        public int ItemCount { get; set; }
    }
}