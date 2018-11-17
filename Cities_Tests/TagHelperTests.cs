using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cities_Tests
{
    public class TagHelperTests
    {
        [Fact(DisplayName = "ButtonTagHelper => when processed correctly modifies the html attbribute on a button")]
        public void TestTagHelper()
        {
            // Arrange
            var tagHelperContext = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "myuniqueid");
            var tagHelperOutput = new TagHelperOutput(
                "button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            // Act
            var buttonTagHelper = new ButtonTagHelper { BsButtonColor = "testValue"};
            buttonTagHelper.Process(tagHelperContext, tagHelperOutput);

            // Assert
            Assert.Equal($"btn btn-{buttonTagHelper.BsButtonColor}", tagHelperOutput.Attributes["class"].Value);
        }
    }
}
