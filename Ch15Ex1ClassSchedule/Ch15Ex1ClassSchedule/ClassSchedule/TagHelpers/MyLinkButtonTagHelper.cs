using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("my-link-button")]
    public class MyLinkButtonTagHelper : TagHelper
    {
        private readonly LinkGenerator linkGenerator;

        public MyLinkButtonTagHelper(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        public string? Action { get; set; }
        public string? Controller { get; set; }
        public string? Id { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string action = Action ??
                ViewContext.RouteData.Values["action"]?.ToString() ?? "";

            string controller = Controller ??
                ViewContext.RouteData.Values["controller"]?.ToString() ?? "";

            var id = new { id = Id };

            string url = linkGenerator.GetPathByAction(
                action: action,
                controller: controller,
                values: id) ?? "";

            string currentId = ViewContext.RouteData.Values["id"]?.ToString() ?? "";
            string css = (currentId == Id)
                ? "btn btn-dark"
                : "btn btn-outline-dark";

            output.BuildLink(url, css);
        }
    }
}