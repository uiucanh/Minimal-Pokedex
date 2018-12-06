using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Infrastructure
{
    [HtmlTargetElement("type")]
    public class TypeTagHelper : TagHelper
    {
        public string TypeName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            var typeName = "type" + TypeName;
            output.Attributes.SetAttribute("class", typeName);
            output.Content.SetContent(TypeName);
        }
    }
}
