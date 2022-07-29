using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSE.Identidade.API.Extensions;
using NSE.Identidade.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]// Além de identificar que é uma APIController, o swagger add os Schemas 
    [Route("api-identidade")]
    public class AuthController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppSettings _appSettings;

        public AuthController(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager,
                             IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value; // O valor de IOptions é uma instacia de AppSettings
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            return BadRequest();

        }
        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userName: usuarioLogin.Email, password: usuarioLogin.Senha, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        public async Task<UsuarioRespostaLogin> GerarJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            //Adicionando claims 

            claims.Add(new Claim(type:JwtRegisteredClaimNames.Sub,value: user.Id));
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Email, value: user.Email));
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()));
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Nbf, value: ToUnixEpochDate(DateTime.UtcNow).ToString())); // Quando o token vai expirar
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Iat, value: ToUnixEpochDate(DateTime.UtcNow).ToString(),ClaimValueTypes.Integer64));//quanto o token foi emitido

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(type: "role", value: userRole));
            }

            //Adicionando Claims criadas acima no IdentityClaims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            //Gerando o manipulador do Token
            var tokenHandler = new JwtSecurityTokenHandler();

            //gerando a chave
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            //Gerando Token 
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),///2 horas a+ no padrão utc
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key),algorithm:SecurityAlgorithms.HmacSha256Signature)
            });



        }

        /// <summary>
        ///  Método Que define como exibir uma data, jwt precisa desse padrão
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)).TotalSeconds);
    }

}