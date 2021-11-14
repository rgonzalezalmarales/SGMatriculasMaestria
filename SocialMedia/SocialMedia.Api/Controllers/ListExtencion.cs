using System.Collections.Generic;

namespace SocialMedia.Api.Controllers.Ext
{
    public static class ListExtencion
    {
        public static int Largo(this List<int> list)
        {
            return list.Count;
        }
    }
}
