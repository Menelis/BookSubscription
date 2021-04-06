using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Serialization
{
    public class JsonSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, settings);
        }
        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver { }
    }
}
