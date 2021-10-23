using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        class CustomResolver : DefaultContractResolver
        {
            private readonly List<string> _namesOfVirtualPropsToKeep = new List<string>(new String[] { });

            public CustomResolver() { }

            public CustomResolver(IEnumerable<string> namesOfVirtualPropsToKeep)
            {
                this._namesOfVirtualPropsToKeep = namesOfVirtualPropsToKeep.Select(x => x.ToLower()).ToList();
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty prop = base.CreateProperty(member, memberSerialization);
                var propInfo = member as PropertyInfo;
                if (propInfo != null)
                {
                    if (propInfo.GetMethod.IsVirtual && !propInfo.GetMethod.IsFinal
                                                     && !_namesOfVirtualPropsToKeep.Contains(propInfo.Name.ToLower()))
                    {
                        prop.ShouldSerialize = obj => false;
                    }
                }
                return prop;
            }
        }
        public static string ToJson(this object @object) => JsonConvert.SerializeObject(@object);
        public static string ToJsonWithoutNavs(this object @object) => JsonConvert.SerializeObject(@object, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CustomResolver()
        });
    }
}