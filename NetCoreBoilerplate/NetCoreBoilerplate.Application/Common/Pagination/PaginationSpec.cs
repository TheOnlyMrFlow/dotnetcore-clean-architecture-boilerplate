using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Common.Pagination
{
    public class PaginationSpec
    {
        public PaginationSpec(int page, int perPage)
        {
            Page = page;
            PerPage = perPage;
        }

        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
