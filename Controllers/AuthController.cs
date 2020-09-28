using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UrlShortener.Entities;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(model.Email);
                return Ok(new UserInfo { UserId = newUser.Id, Email = model.Email });
            }
            else
            {
                return BadRequest("username or password faild");
            }


        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,  false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Username);
                return Ok(new UserInfo { UserId = user.Id, Email = model.Username  });
            }
            else
            {
                
                return BadRequest();
            }

        }

        //private ActionResult<UserToken> BuildToken()
        //{
        //    var claims 
        //}
    }
}
