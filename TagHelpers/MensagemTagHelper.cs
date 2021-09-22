
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Texto { get; set; }

        //<mensagem texto=""></mensagem>
        //<div class="alert alert-success">texto</div>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                //nome da tag
                output.TagName = "div";
                //atributo class
                output.Attributes.SetAttribute("class", "alert alert-success");
                //conteúdo da tag
                output.Content.SetContent(Texto);
            }
        }
    }
}
