using Microsoft.AspNetCore.Mvc;
using A._4_DemoMvcViews.Models;
using System.Diagnostics;
namespace A._4_DemoMvcViews.ViewComponents

    // Aula 4.6 ViewComponents
{  //Passo 1 criar classe do ViewComponent
    [ViewComponent(Name = "Carrinho")]
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
