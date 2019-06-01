using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UEditor.Core;
using UEditor.Core.Handlers;

namespace JXWebHost.Controllers
{
    public class UEditorController : Controller
    {
        private readonly UEditorService _ueditorService;
        public UEditorController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }

        [HttpGet, HttpPost]
        public ContentResult Upload()
        {
			var uploadConfig = ConfigHelper.Get<UploadFilesConfig>();
			if (!uploadConfig.EnableUploadFiles)
			{
				UEditorResult Result = new UEditorResult();
				Result.State = "没有开启上传权限";
				Result.Error = "没有开启上传权限";
				string resultJson = JsonConvert.SerializeObject(Result, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				return Content(resultJson, "text/plain");
			}
			var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }
    }
}