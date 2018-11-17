using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("formbutton")]
    public class FormButtonTagHelper : TagHelper
    {
        public string Type { get; set; } = "Submit";

        public string BgColor { get; set; } = "primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", $"btn btn-{BgColor}");
            output.Attributes.SetAttribute("type", Type);
            
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            output.Content.SetContent(textInfo.ToTitleCase(Type));
        }
    }
}
