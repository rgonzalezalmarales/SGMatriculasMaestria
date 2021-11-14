using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Core.CustomEntities
{
    public class CustomPagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int? PreviousPage => HasPreviousPage ? CurrentPage - 1 : (int?)null;
        public int? NextPage => HasNextPage ? CurrentPage + 1 : (int?)null;

        public CustomPagedList(IEnumerable<T> collection, int currentPage, int pageSize)
        {
            TotalCount = collection.Count();
            var source = collection.Skip((currentPage - 1) * pageSize).Take(pageSize);
            AddRange(source);
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
