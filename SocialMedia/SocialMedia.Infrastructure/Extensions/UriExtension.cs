using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Extensions
{
    public static class UriExtension
    {
        public static Uri addQuery(this Uri uri, string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
                return uri;
            //this actually returns HttpValueCollection: NameValueCollection
            //which uses unicode compliant encoding on ToString

            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            query.Add(name, value);

            var uriBuilder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            return uriBuilder.Uri;
        }

        public static Uri addQuery(this Uri uri, Dictionary<string, string> queries)
        {
            foreach (var query in queries)
            {
                uri = uri.addQuery(query.Key, query.Value);
            }
            return uri;
        }

        public static Uri addQuery<T>(this Uri uri, T filters) where T : class
        {
            //var query = new System.Collections.Specialized.NameValueCollection();
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(filters);
            var dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach (var item in dictionary)
            {
                query.Add(item.Key, item.Value);
            }

            var uriBuilder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            return uriBuilder.Uri;
        }
    }
}
