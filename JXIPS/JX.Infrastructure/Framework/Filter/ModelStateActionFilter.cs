using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JX.Infrastructure.Framework.Filter
{
    /// <summary>
    /// 页面统一模型验证处理。在Startup.cs文件的ConfigureServices方法中，添加services.AddMvc(options =>{options.Filters.Add《ModelStateActionFilter》();})
    /// </summary>
    public class ModelStateActionFilter : IActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //context.Result = new BadRequestObjectResult(context.ModelState);
                foreach (var value in context.ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        context.ModelState.AddModelError(string.Empty, error.ErrorMessage);
                    }
                }
                context.Result = new ViewResult();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
