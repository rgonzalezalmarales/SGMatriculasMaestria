using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppPagination.Models
{
    public abstract class FilterModelBase : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public FilterModelBase()
        {
            Page = 1;
            Limit = 100;
        }

        public abstract object Clone();
    }

    public class SampleFilterModel : FilterModelBase
    {
        public string Term { get; set; }
        public SampleFilterModel() : base()
        {
            Limit = 3;
        }
        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            var result = JsonConvert.DeserializeObject(jsonString, this.GetType());
            return result;
        }
    }

    //
    //public string MinDate { get; set; }
    //public Boolean IncludeInactive { get; set; }


    //public class FilterModel
    //{
    //    public string Term { get; set; }
    //    public string MinDate { get; set; }
    //    public Boolean IncludeInactive { get; set; }
    //    public int Page { get; set; }
    //    public int Limit { get; set; }
    //}

    public class PageColectionResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        //public int TotalRows { get => Items.Count(); }
        //public int TotalPages { get => Query.Limit > 0? TotalRows / Query.Limit : 0; }
        public int TotalPages { get; set; }
        public FilterModelBase Query { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        
    }
}
