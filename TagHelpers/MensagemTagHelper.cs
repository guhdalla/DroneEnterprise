﻿
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "alert alert-success");
                output.Content.SetContent(Texto);
            }
        }
    }
}
