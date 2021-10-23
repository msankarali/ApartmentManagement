using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ApartmentManagement.Mvc.TagHelpers
{
    public class BoolTagHelper : TagHelper
    {
        public bool? Bool { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            switch (Bool)
            {
                case true:
                    output.Content.SetHtmlContent("<i class=\"fas fa-check\"></i>");
                    break;

                case false:
                    output.Content.SetHtmlContent("<i class=\"fas fa-times\"></i>");
                    break;

                case null:
                    output.Content.SetHtmlContent("<i class=\"fas fa-minus\"></i>");
                    break;
            }

            output.TagName = "span";
        }
    }
}