using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ikvm.runtime;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DevIO.UI.Site.Extensions
{   /// <summary>
    /// Classe para criação de Tag Helper customizado para email 
    /// </summary>
    public class EmailTagHelper : TagHelper
    {

        public string EmailDomain { get; set; } = "desenvolvedor.io";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";//Informando que a saida é uma tag link a 
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
