using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Dynamic.Duck;

namespace Dynamic.Json
{
    public static class JObject_Extensions
    {
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design.")]
        public static T AsIf<T>(this JObject target) where T : class
        {
            DynamicObject o = AsDynamic(target);
            return DynamicDuck.AsIf<T>(o);
        }

        public static dynamic AsDynamic(this JObject target)
        {
            return new DynamicJsonObject(target);
        }
    }
}
