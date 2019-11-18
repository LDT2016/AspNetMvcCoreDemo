using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDemo.Filter
{
    /// 
    /// 隐藏swagger接口特性标识
    /// 
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HiddenApiAttribute : System.Attribute
    {
    }
    public class HiddenApiFilter: IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.TryGetMethodInfo(out MethodInfo method))
                {
                    if (method.ReflectedType.CustomAttributes.Any(t => t.AttributeType == typeof(HiddenApiAttribute))
                        || method.CustomAttributes.Any(t => t.AttributeType == typeof(HiddenApiAttribute)))
                    {
                        string key = "/" + apiDescription.RelativePath;
                        if (key.Contains("?"))
                        {
                            int idx = key.IndexOf("?", System.StringComparison.Ordinal);
                            key = key.Substring(0, idx);
                        }
                        swaggerDoc.Paths.Remove(key);
                    }
                }
            }

            swaggerDoc?.Definitions?.Clear();


            //// add enum descriptions to result models
            //foreach (KeyValuePair<string, Schema> schemaDictionaryItem in swaggerDoc.Definitions)
            //{
            //    Schema schema = schemaDictionaryItem.Value;
            //    foreach (KeyValuePair<string, Schema> propertyDictionaryItem in schema.Properties)
            //    {
            //        Schema property = propertyDictionaryItem.Value;
            //        IList<object> propertyEnums = property.Enum;
            //        if (propertyEnums != null && propertyEnums.Count > 0)
            //        {
            //            property.description += DescribeEnum(propertyEnums);
            //        }
            //    }
            //}

            //// add enum descriptions to input parameters
            //if (swaggerDoc.paths.Count > 0)
            //{
            //    foreach (PathItem pathItem in swaggerDoc.paths.Values)
            //    {
            //        DescribeEnumParameters(pathItem.parameters);

            //        // head, patch, options, delete left out
            //        List<Operation> possibleParameterisedOperations = new List<Operation> { pathItem.get, pathItem.post, pathItem.put };
            //        possibleParameterisedOperations.FindAll(x => x != null).ForEach(x => DescribeEnumParameters(x.parameters));
            //    }
            //}
        }
    }
}
