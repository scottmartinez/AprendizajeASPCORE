using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSistemaVsShopify.CustomTagHelper
{
    [HtmlTargetElement("tr",Attributes= "ordenarpor,tamaniopagina,IsAscendente,buscar")]
    public class OrdenadorTagHelper:TagHelper
    {
        private const int V=0;
        private IUrlHelperFactory urlHelperFactory ;
        public  OrdenadorTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        #region Atributos de Entrada
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("IsAscendente")]
        public bool IsAscendente { get; set; }
        [HtmlAttributeName("ordenarpor")]
        public int ordenarpor { get; set; }
        [HtmlAttributeName("tamaniopagina")]
        public int? tamaniopagina { get; set; }
        [HtmlAttributeName("buscar")]
        public string buscar { get; set; }
        #endregion
        public override void Process(TagHelperContext context,TagHelperOutput output)
        {
            IUrlHelper urlHelper=urlHelperFactory.GetUrlHelper(ViewContext);
            List<string> li=new List<string>()
            {
                                        "PLM","Codigo Producto","Nombre Producto","Existencia","Colección","Temporada","Und. Neg.","Precio"
            };
            TagBuilder tr= new TagBuilder("tr");
            int headeid=V;
            for(int row = 0;row <=7;row++)
            {
                TagBuilder th= new TagBuilder("th");
                TagBuilder tag= new TagBuilder("a");
                var  toggesort= (row==ordenarpor ? (!IsAscendente).ToString():"true");
                tag.Attributes["href"] = urlHelper.Action("Grilla","ExistenciasBusqueda",new { 
                    ordenarpor = row,IsAscendente = toggesort,buscar = buscar});
                tag.InnerHtml.AppendHtml(li[row]);
                if(ordenarpor!=0)
                {
                    if(row==ordenarpor)
                    {
                        TagBuilder tagspan= new TagBuilder("span");
                        tagspan.AddCssClass($"arrow.{(IsAscendente?"up":"down")}");
                        th.InnerHtml.AppendHtml(tagspan);
                    }
                }

                th.InnerHtml.AppendHtml(tag);
                tr.InnerHtml.AppendHtml(th);
                headeid += 1;

           
            }
            output.Content.AppendHtml(tr.InnerHtml);
           
        }
    }
}
