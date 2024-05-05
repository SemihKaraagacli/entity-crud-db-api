using EntityDBWebApi.Models;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EntityDBWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ResponseModel Login(LoginModel loginModel)
        {
            if (loginModel.Username == "semih" && loginModel.Password == "123")
            {

                var signingKey = "BuBenimSigningKey123456789BuBenimSigningKey123456789BuBenimSigningKey123456789BuBenimSigningKey123456789BuBenimSigningKey123456789"; // parolamız
                var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)), SecurityAlgorithms.HmacSha512); //parolamızı gizlediğimiz yer

                var endcoded=JWT.Encode(loginModel.Username, Encoding.UTF8.GetBytes(signingKey),JwsAlgorithm.HS512);//username gizlemem

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, endcoded) //burada jwt içerisinde katılımcı adını göstermek için yada gizlemek için oluşturduğumuz bir alan
                };
                var securityToken = new JwtSecurityToken(
                    issuer: "http://www.semih.com",
                    audience: "bu token benim için",
                    expires: DateTime.Now.AddDays(2),
                notBefore: DateTime.Now,
                    claims: claims,
                    signingCredentials: credential
                    ); //token bilgilerimiz
                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);// tokenı ürettiğimiz yer


                return new ResponseModel()
                {
                    Message = "Login işlemi başarılı",
                    Code = "200",
                    Data = token
                };

            }
            return new ResponseModel()
            {
                Message = "Login işlemi başarısız",
                Code = "101",
                Data = null
            };
        }
    }
}
