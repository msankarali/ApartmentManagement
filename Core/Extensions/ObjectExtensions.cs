using System;
using Newtonsoft.Json;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object @object) => JsonConvert.SerializeObject(@object);
    }
}