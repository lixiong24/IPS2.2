using JXWebHost.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	[ViewComponent(Name = "MorePic")]
	public class MorePicViewComponent : ViewComponent
	{
		public MorePicViewComponent()
		{

		}

		public async Task<IViewComponentResult> InvokeAsync(MorePicViewModel morePicViewModel=null)
		{
			morePicViewModel = await GetMorePicViewModelAsync(morePicViewModel);
			return View(morePicViewModel);
		}

		private Task<MorePicViewModel> GetMorePicViewModelAsync(MorePicViewModel morePicViewModel)
		{
			if (morePicViewModel == null)
			{
				morePicViewModel = new MorePicViewModel();
			}
			return Task.FromResult(morePicViewModel);
		}
	}
}
