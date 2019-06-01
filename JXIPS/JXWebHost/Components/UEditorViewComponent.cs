using JXWebHost.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	[ViewComponent(Name = "UEditor")]
	public class UEditorViewComponent : ViewComponent
	{
		public UEditorViewComponent()
		{

		}

		public async Task<IViewComponentResult> InvokeAsync(UEditorViewModel viewModel =null)
		{
			viewModel = await GetMorePicViewModelAsync(viewModel);
			return View(viewModel);
		}

		private Task<UEditorViewModel> GetMorePicViewModelAsync(UEditorViewModel viewModel)
		{
			if (viewModel == null)
			{
				viewModel = new UEditorViewModel();
			}
			return Task.FromResult(viewModel);
		}
	}
}
