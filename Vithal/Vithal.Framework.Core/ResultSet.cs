using System.Collections.Generic;

namespace Vithal.Framework.Core
{
    public class ResultSet<T> where T : BaseEntity
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int SkipCount { get; set; }
        public int TotalRows { get; set; }
        public IEnumerable<T> Rows { get; set; }
    }
}
