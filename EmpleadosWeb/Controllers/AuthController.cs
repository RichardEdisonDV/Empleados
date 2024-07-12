using Application.Features.TipoUsuarios.Queries.GetTipoUsuarios;
using Application.Features.Usuarios.Commands.RegisterUser;
using Application.Features.Usuarios.Commands.SignInByEmailPassword;
using EmpleadosWeb.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmpleadosWeb.Controllers
{
    public class AuthController(IMediator mediator) : BaseController(mediator)
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseTipoUsuario = await Mediator.Send(new GetTipoUsuariosQuery());
            ViewBag.TipoUsuarios = responseTipoUsuario.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserCommand request)
        {
            var response = await Mediator.Send(request);

            if (response is not null && response.Succeeded && response!.Errors.Count == 0 && response.Data is not null)
            {
                var jsonData = JsonConvert.SerializeObject(response);
                HttpContext.Session.SetString("userinfo", jsonData);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] SignInByEmailPasswordCommand request)
        {
            var response = await Mediator.Send(request);

            if (response is not null && response.Succeeded && response!.Errors.Count == 0 && response.Data is not null)
            {
                var jsonData = JsonConvert.SerializeObject(response);
                HttpContext.Session.SetString("userinfo", jsonData);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userinfo");
            ViewBag.User = null;
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
