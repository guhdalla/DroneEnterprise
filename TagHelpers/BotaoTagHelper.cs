using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        public string Texto { get; set; }
        public string Class { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "submit");
            if (string.IsNullOrEmpty(Class))
            {
                output.Attributes.SetAttribute("class", "btn btn-success");
            }
            else
            {
                output.Attributes.SetAttribute("class", Class);
            }
            output.Attributes.SetAttribute("value", string.IsNullOrEmpty(Texto)?"Cadastrar":Texto);
        }
    }
}
