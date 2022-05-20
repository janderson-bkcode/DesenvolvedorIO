using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace DevIO.UI.Site.ViewsComponents
 {

    [ViewComponent(Name ="Carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        public int ItensCarrinho { get; set; }

        public CarrinhoViewComponent()
        {
            ItensCarrinho = 3;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensCarrinho);
        }

    }
}
