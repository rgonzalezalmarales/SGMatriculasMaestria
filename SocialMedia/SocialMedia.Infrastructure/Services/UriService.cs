using Newtonsoft.Json;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using SocialMedia.Infrastructure.Extensions;
using SocialMedia.Core.Enumerations;
using SocialMedia.Infrastructure.Enumerations;

namespace SocialMedia.Infrastructure.Services
{
    
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        //Función GetPostPaginationUrl
        public Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl, PaginationDirection direction = PaginationDirection.Next)
        {
            PostQueryFilter queryFilters = filters.Copy();
            switch (direction)
            {
                case PaginationDirection.Previous:
                    queryFilters.PageNumber--;
                    break;
                default:
                    queryFilters.PageNumber++;
                    break;
            }
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl).addQuery(queryFilters);
        }

        #region Método GetPostPaginationUrl sin aplicar extension metodos, con mi lógica
        //public Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl)
        //{
        //   System.Reflection.PropertyInfo[] properties = typeof(PostQueryFilter).GetProperties();
        //    string queryFilters = string.Empty;

        //    foreach (var property in properties)
        //    {
        //        string filter = property.Name;
        //        var filterValue = property.GetValue(filters);

        //        if (filterValue != null)
        //            queryFilters = queryFilters.Length == 0 ? string.Concat("?", filter, "=", filterValue) : string.Concat(queryFilters, "&", filter, "=", filterValue);
        //    }

        //    string baseUrl = $"{_baseUri}{actionUrl}{queryFilters}";
        //    var uri = new Uri(baseUrl);
        //    return uri;
        //}

        //public Uri GetPostPaginationNextUrl(PostQueryFilter filters, string actionUrl)
        //{
        //    var json = JsonConvert.SerializeObject(filters);
        //    var nextFilters = JsonConvert.DeserializeObject<PostQueryFilter>(json);
        //    nextFilters.PageNumber++;
        //    return GetPostPaginationUrl(nextFilters, actionUrl);
        //}

        //public Uri GetPostPaginationPreviousUrl(PostQueryFilter filters, string actionUrl)
        //{
        //    var json = JsonConvert.SerializeObject(filters);
        //    var previousFilters = JsonConvert.DeserializeObject<PostQueryFilter>(json);
        //    previousFilters.PageNumber--;
        //    return GetPostPaginationUrl(previousFilters, actionUrl);
        //}

        #endregion

    }
}
