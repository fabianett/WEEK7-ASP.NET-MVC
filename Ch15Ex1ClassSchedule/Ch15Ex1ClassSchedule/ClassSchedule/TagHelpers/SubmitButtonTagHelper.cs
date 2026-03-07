using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("submit-button")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public string ButtonText { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("button", "btn btn-dark");
            output.Attributes.SetAttribute("type", "submit");
            output.Content.SetContent(ButtonText);
        }
    }
}