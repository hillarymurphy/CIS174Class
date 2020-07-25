using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Areas.Agile.TagHelpers
{
    [HtmlTargetElement(Attributes = "[type=submit]")]
    public class SubmtitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context,
       TagHelperOutput output)
        {
            //make button element
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;

            //make a submit button
            output.Attributes.SetAttribute("type", "submit");

            //append bootstrap button classes
            string newClasses = "btn btn-dark";
            string oldClasses = output.Attributes["class"]?.Value?.ToString();
            string classes = (string.IsNullOrEmpty(oldClasses)) ?
                newClasses : $"{oldClasses} {newClasses}";
            output.Attributes.SetAttribute("class", classes);

        }
    }
}

