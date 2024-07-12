using Application.Features.Emparejamientos.Commands.Create;
using Application.Features.Emparejamientos.Commands.Delete;
using Application.Features.Vacantes.Queries.GetVacantes;
using EmpleadosWeb.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosWeb.Controllers
{
    public class VacanteController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await Mediator.Send(new GetVacantesQuery());
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Aplicar(CreateEmparejamientoCommand request)
        {
            _ = await Mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> NoAplicar(DeleteEmparejamientoCommand request)
        {
            await Mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
