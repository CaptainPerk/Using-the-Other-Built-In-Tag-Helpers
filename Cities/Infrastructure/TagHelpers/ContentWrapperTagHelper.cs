using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "title")]
    public class ContentWrapperTagHelper : TagHelper
    {
        public bool IncludeHeader { get; set; } = true;
        public bool IncludeFooter { get; set; } = true;
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "m-1 p-1");

            var titleTagBuilder = new TagBuilder("h1");
            titleTagBuilder.InnerHtml.Append(Title);

            var containerTagBuilder = new TagBuilder("div");
            containerTagBuilder.Attributes["class"] = "bg-info m-1 p-1";
            containerTagBuilder.InnerHtml.AppendHtml(titleTagBuilder);

            if (IncludeHeader)
            {
                output.PreElement.SetHtmlContent(containerTagBuilder);
            }

            if (IncludeFooter)
            {
                output.PostElement.SetHtmlContent(containerTagBuilder);
            }
        }
    }
}
