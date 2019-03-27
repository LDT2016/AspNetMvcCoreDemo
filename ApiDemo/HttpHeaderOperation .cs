using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//添加引用
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDemo
{
    public class HttpHeaderOperation : IOperationFilter
    {
        /// <summary>
        /// 实现接口
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            var actionAttrs = context.ApiDescription.ActionAttributes();

            var isAuthorized = actionAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));

            if (isAuthorized == false) //提供action都没有权限特性标记，检查控制器有没有
            {
                var controllerAttrs = context.ApiDescription.ControllerAttributes();

                isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            }

            var isAllowAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));

            if (isAuthorized && isAllowAnonymous == false)
            {
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "Authorization",  //添加Authorization头部参数
                    In = "header",
                    Type = "string",
                    Required = false
                });
            }
        }
    }
}
