using DevIO.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.api.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : MainController
    {
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {

            return Ok();
        }
    }
}
