namespace MyFirstAspNetCoreApp.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("h1")]
    public class GreetingHeaderTagHelper : TagHelper
    {
        public string GreetingString { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("name", "Niki");
            output.Content.SetContent(GreetingString);
            base.Process(context, output);
        }
    }
}
