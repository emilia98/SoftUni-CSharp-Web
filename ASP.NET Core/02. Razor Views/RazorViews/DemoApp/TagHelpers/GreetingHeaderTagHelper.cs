using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoApp.TagHelpers
{
    [HtmlTargetElement("h1", Attributes = "greeting-string")]
    [HtmlTargetElement("h2", Attributes = "greeting-string")]
    [HtmlTargetElement("h3", Attributes = "greeting-string")]
    [HtmlTargetElement("h4", Attributes = "greeting-string")]
    public class GreetingHeaderTagHelper : TagHelper
    {
        public string GreetingString { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("name", "niki");
            output.Content.SetContent(GreetingString);
            output.Content.AppendHtml("<button class=\"btn btn-primary\">Just Button</button>");
            base.Process(context, output);
        }
    }
}
