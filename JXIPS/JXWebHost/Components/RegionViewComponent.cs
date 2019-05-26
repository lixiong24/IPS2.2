using JXWebHost.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	[ViewComponent(Name = "Region")]
	public class RegionViewComponent : ViewComponent
	{
		public RegionViewComponent()
		{

		}

		public async Task<IViewComponentResult> InvokeAsync(RegionViewModel regionViewModel =null)
		{
			regionViewModel = await GetRegionViewModelAsync(regionViewModel);
			return View(regionViewModel);
		}

		private Task<RegionViewModel> GetRegionViewModelAsync(RegionViewModel regionViewModel)
		{
			if (regionViewModel == null)
			{
				regionViewModel = new RegionViewModel();
			}
			return Task.FromResult(regionViewModel);
		}
	}
}
