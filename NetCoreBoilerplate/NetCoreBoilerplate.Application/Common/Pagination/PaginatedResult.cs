using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Common.Pagination
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Result { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public int TotalPages { get; set; }

        public PaginatedResult<TResult> Select<TResult>(Func<T, TResult> selector)
            => new PaginatedResult<TResult>()
            {
                Page = Page,
                PerPage = PerPage,
                TotalPages = TotalPages,
                Result = Result.Select(selector)
            };
    }
}
