using APIBACK.Models.Minikura.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APIBACK
{
    public static class Extensions
    {
        public static Uri GetUri(this HttpClient http, string path, IEnumerable<KeyValuePair<string, string>> param)
        {
            var uriBuilder = new UriBuilder(Path.Combine(http.BaseAddress.ToString(), path));

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var pair in param)
            {
                parameters[pair.Key] = pair.Value;
            }
            uriBuilder.Query = parameters.ToString();

            return uriBuilder.Uri;
        }


        public static T To<T>(this IEnumerable<KeyValuePair<string, StringValues>> collection)
        {
            var t = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties();
            foreach (var item in collection)
            {
                var target = props.FirstOrDefault(P => P.Name == item.Key);
                if (target != null)
                {
                    if (target.PropertyType == typeof(DateTime?))
                    {
                        DateTime? f = DateTime.Parse(item.Value);
                        target.SetValue(t, f);
                    }
                    else
                        target.SetValue(t, item.Value.ToString());
                }
            }
            return t;
        }

        public static Dictionary<string, string> AsDictionary(this object value)
        {
            return value.
                GetType()
                .GetProperties()
                .Select(P => (name: P.Name, value: P.GetValue(value)))
                .Where(P => P.value != null)
                .ToDictionary(P => P.name, P => P.value.ToString());
        }
    }
}
