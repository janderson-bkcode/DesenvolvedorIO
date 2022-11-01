using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Site.Extensions
{
	public class FooterSiteTagHelper : TagHelper
	{
		public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "p";
			var content = await output.GetChildContentAsync();
			var target = content.GetContent() + $"Copyright @@ {@DateTime.Now.Year}";
			output.Content.SetHtmlContent(target);
		}
	}
}
