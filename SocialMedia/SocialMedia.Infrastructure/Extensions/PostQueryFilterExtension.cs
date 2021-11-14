using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Extensions
{
    public static class PostQueryFilterExtension
    {
        public static PostQueryFilter Copy(this PostQueryFilter postQueryFilter)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(postQueryFilter);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PostQueryFilter>(json);
        }
    }
}
