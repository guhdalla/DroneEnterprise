using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        //As propriedades são os atributos das tags
        public string Texto { get; set; }
        public string Class { get; set; }

        //<botao texto="" class=""></botao>
        //<input type="submit" value="Cadastrar" class="btn btn-success"/>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag
            output.TagName = "input";
            //Definir os atributos da tag (type, value, class)
            output.Attributes.SetAttribute("type", "submit");
            if (string.IsNullOrEmpty(Class)) //valida se a Class está vazia o null
            {
                output.Attributes.SetAttribute("class", "btn btn-success");
            }
            else
            {
                output.Attributes.SetAttribute("class", Class);
            }
            //Ternário..
            output.Attributes.SetAttribute("value", string.IsNullOrEmpty(Texto)?"Cadastrar":Texto);
        }
    }
}
