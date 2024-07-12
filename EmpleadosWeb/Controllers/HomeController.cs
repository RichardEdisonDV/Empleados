using Application.DTOs;
using Application.Features.Demandantes.Queries.GetDemandanteById;
using Application.Features.Empleadores.Queries.GetEmpleadorById;
using Application.Wrappers;
using EmpleadosWeb.Controllers.Common;
using EmpleadosWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EmpleadosWeb.Controllers
{
    public class HomeController(IMediator mediator, ILogger<HomeController> logger) : BaseController(mediator)
    {
        private readonly ILogger<HomeController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            bool sessionExists = !string.IsNullOrEmpty(HttpContext.Session.GetString("userinfo"));

            if (sessionExists)
            {
                var userString = HttpContext.Session.GetString("userinfo");
                var userWrapper = string.IsNullOrEmpty(userString) ? null : JsonConvert.DeserializeObject<WrapperResponse<UsuarioDto>>(userString);
                var user = userWrapper?.Data;

                if (user is not null)
                {
                    if (user.TipoUsuarioId == 1) // Demandante
                    {
                        var response = await Mediator.Send(new GetDemandanteByIdQuery { Id = user.Id });
                        if(response is null || response.Data is null)
                        {
                            return RedirectToAction("Crear", "Demandante");
                        }
                        return RedirectToAction("Profile", "Demandante", new { id = user.Id });
                    }
                    else if (user.TipoUsuarioId == 2) // Empleador
                    {
                        var response = await Mediator.Send(new GetEmpleadorByIdQuery { Id = user.Id });
                        if (response is null || response.Data is null)
                        {
                            return RedirectToAction("Crear", "Empleador");
                        }
                        return RedirectToAction("Profile", "Empleador", new { id = user.Id });
                    }
                    return RedirectToAction("Index", "Auth");
                }
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
