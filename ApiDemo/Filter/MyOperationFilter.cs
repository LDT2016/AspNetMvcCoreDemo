﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDemo.Controllers
{
    public class MyOperationFilter: ISchemaFilter
    {
        #region Implementation of IOperationFilter

        public void Apply(Schema schema, SchemaFilterContext schemaFilterContext)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            const BindingFlags bindingFlags = BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance;
            var memberList = schemaFilterContext.SystemType
                                                .GetFields(bindingFlags).Cast<MemberInfo>()
                                                .Concat(schemaFilterContext.SystemType
                                                                           .GetProperties(bindingFlags));

            var excludedList = memberList.Where(m =>
                                                    m.GetCustomAttribute<SwaggerIgnoreAttribute>()
                                                    != null)
                                         .Select(m =>
                                                     (m.GetCustomAttribute<JsonPropertyAttribute>()
                                                       ?.PropertyName
                                                      ?? m.Name.ToCamelCase()));

            foreach (var excludedName in excludedList)
            {
                if (schema.Properties.ContainsKey(excludedName))
                    schema.Properties.Remove(excludedName);
            }
        }

        #endregion

        #region Implementation of ISchemaFilter

        #endregion
    }

    internal static class StringExtensions
    {
        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
