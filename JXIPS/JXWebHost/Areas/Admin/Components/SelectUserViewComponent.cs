using JX.Core.Entity;
using JX.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace JXWebHost.Areas.Admin.Components
{
	[ViewComponent(Name = "SelectUser")]
	public class SelectUserViewComponent : ViewComponent
	{
		public SelectUserViewComponent()
		{
			
		}

		public async Task<IViewComponentResult> InvokeAsync(SelectUserViewModel viewModel = null)
		{
			viewModel = await GetViewModelAsync(viewModel);
			return View(viewModel);
		}

		private Task<SelectUserViewModel> GetViewModelAsync(SelectUserViewModel viewModel)
		{
			if (viewModel == null)
			{
				viewModel = new SelectUserViewModel();
			}
			return Task.FromResult(viewModel);
		}
	}
}
