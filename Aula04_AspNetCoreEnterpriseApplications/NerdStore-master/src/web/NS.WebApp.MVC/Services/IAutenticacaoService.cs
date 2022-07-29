using NS.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
