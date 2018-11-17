using Cities.Models;
using Cities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectOptionTagHelper : TagHelper
    {
        private readonly ICityRepository _cityRepository;

        public SelectOptionTagHelper(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(await output.GetChildContentAsync(false)).GetContent();

            var selected = ModelFor.Model as string;

            var propertyInfo = typeof(City).GetTypeInfo().GetDeclaredProperty(ModelFor.Name);
            foreach (string country in _cityRepository.Cities.Select(c => propertyInfo.GetValue(c)).Distinct())
            {
                if (selected != null && selected.Equals(country, StringComparison.OrdinalIgnoreCase))
                {
                    output.Content.AppendHtml($"<option selected>{country}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option>{country}</option>");
                }
            }
            output.Attributes.SetAttribute("Name", ModelFor.Name);
            output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}
