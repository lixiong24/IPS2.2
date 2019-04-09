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
	[ViewComponent(Name = "Nav")]
	public class NavViewComponent: ViewComponent
	{
		public NavViewComponent()
		{
			
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			IList<SiteMapEntity> siteMapEntity = await GetSiteMapAsync();
			return View(siteMapEntity);
		}

		private Task<IList<SiteMapEntity>> GetSiteMapAsync()
		{
			IList<SiteMapEntity> siteMapEntity = new List<SiteMapEntity>();
			XmlHelper xmlHelper = XmlHelper.Instance(FileHelper.MapPath("~/Config/AdminSiteMap.xml"), XmlType.File);
			XmlDocument xmlDoc = xmlHelper.XmlDoc;
			XmlNode rootNode = xmlDoc.SelectSingleNode("siteMap");
			if (rootNode != null && rootNode.HasChildNodes)
			{
				var currentUrl = MyHttpContext.Current.Request.Path.Value;
				var arrCurrentUrl = currentUrl.Split("/", StringSplitOptions.RemoveEmptyEntries);
				if(arrCurrentUrl.Length > 1)
				{
					if(DataConverter.CLng(arrCurrentUrl[arrCurrentUrl.Length - 1], -1) > -1)
					{
						currentUrl = currentUrl.Substring(0, currentUrl.LastIndexOf("/"));
					}
				}
				var currentNode = rootNode.SelectSingleNode("//siteMapNode[@url='"+ currentUrl + "']");
				if(currentNode != null)
				{
					string title = XmlHelper.GetAttributesValue(currentNode, "title");
					string Description = XmlHelper.GetAttributesValue(currentNode, "Description");
					string url = XmlHelper.GetAttributesValue(currentNode, "url");
					siteMapEntity.Add(new SiteMapEntity() { Title = title, Url = url, Description = Description });
					if (currentNode.ParentNode != null)
					{
						GetParentNode(currentNode.ParentNode, siteMapEntity);
					}
				}
			}
			return Task.FromResult(siteMapEntity);
		}

		private void GetParentNode(XmlNode xmlNode, IList<SiteMapEntity> siteMapEntity)
		{
			if(xmlNode != null && xmlNode.Name!= "siteMap")
			{
				string title = XmlHelper.GetAttributesValue(xmlNode, "title");
				string Description = XmlHelper.GetAttributesValue(xmlNode, "Description");
				string url = XmlHelper.GetAttributesValue(xmlNode, "url");
				siteMapEntity.Add(new SiteMapEntity() { Title = title, Url = url, Description = Description });
				if(xmlNode.ParentNode != null)
				{
					GetParentNode(xmlNode.ParentNode, siteMapEntity);
				}
			}
		}
	}
}
