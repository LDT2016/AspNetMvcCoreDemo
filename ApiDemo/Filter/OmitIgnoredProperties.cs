using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDemo.Filter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }

    public class OmitIgnoredProperties : IOperationFilter
    {
        //public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        //{
        //    var excludeProperties = new[] { "myProp1", "myProp2", "myProp3" };

        //    foreach (var prop in excludeProperties)
        //        if (schema.Properties.ContainsKey(prop))
        //            schema.Properties.Remove(prop);
        //}
        #region ISchemaFilter Members

        //public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        //{
        //    if (schema?.Properties == null || type == null)
        //        return;

        //    var excludedProperties = type.GetProperties().
        //                                  Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);

        //    foreach (var excludedProperty in excludedProperties)
        //    {
        //        if (schema.properties.ContainsKey(excludedProperty.Name))
        //            schema.properties.Remove(excludedProperty.Name);
        //    }
        //}

        #endregion

        #region Implementation of ISchemaFilter

        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var excludedProperties = context.SystemType.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                if (schema.Properties.ContainsKey(excludedProperty.Name))
                {
                    schema.Properties.Remove(excludedProperty.Name);
                }
            }
        }

        #endregion

        #region Implementation of IOperationFilter

        public void Apply(Operation operation, OperationFilterContext context)
        {
            #region 新方法
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            if (context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {
                if (!methodInfo.CustomAttributes.Any(t => t.AttributeType == typeof(AllowAnonymousAttribute))
                    && !(methodInfo.ReflectedType.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorizeAttribute))))
                {
                    operation.Parameters.Add(new NonBodyParameter
                                             {
                                                 Name = "Authorization",
                                                 In = "header",
                                                 Type = "string",
                                                 Required = true,
                                                 Description = "请输入Token，格式为bearer XXX"
                                             });
                }
            }
            #endregion
        }

        #endregion
    }
}
