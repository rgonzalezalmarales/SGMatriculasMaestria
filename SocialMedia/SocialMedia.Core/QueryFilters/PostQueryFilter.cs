using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.QueryFilters
{
    public class PostQueryFilter
    {
        
        public int? userId { get; set; }
        /// <summary>
        /// Filter posts with this date.
        /// </summary>
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        //public PostQueryFilter()
        //{
        //    PageNumber = 1;
        //    PageSize = 10;
        //}
    }
}
