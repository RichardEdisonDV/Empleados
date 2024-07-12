using Application.Features.Empleadores.Commands.Update;
using Application.Features.Empleadores.Queries.GetEmpleadorById;
using Application.Features.Industrias.Queries.GetIndustrias;
using Application.Features.Localizaciones.Query.GetLocalizaciones;
using Application.Features.Vacantes.Commands.Create;
using Application.Features.Vacantes.Commands.Delete;
using EmpleadosWeb.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosWeb.Controllers
{
    public class EmpleadorController(IMediator mediator) : BaseController(mediator)
    {
        public async Task<IActionResult> Profile(long id)
        {
            var response = await Mediator.Send(new GetEmpleadorByIdQuery { Id = id });
            return View(response.Data);
        }

        public async Task<IActionResult> Crear()
        {
            var industrias = await Mediator.Send(new GetIndustriasQuery());
            var localizaciones = await Mediator.Send(new GetLocalizacionesQuery());
            ViewBag.Industrias = industrias.Data;
            ViewBag.Localizaciones = localizaciones.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EliminarVacante(long empleadorId, long vacanteId)
        {
            var response = await Mediator.Send(new GetEmpleadorByIdQuery { Id = empleadorId });
            ViewBag.Demandante = response.Data;
            await Mediator.Send(new DeleteVacanteCommand { Id = vacanteId });
            return RedirectToAction(nameof(Profile), new { id = empleadorId });
        }

        [HttpGet]
        public async Task<IActionResult> CrearVacante(long id)
        {
            var response = await Mediator.Send(new GetEmpleadorByIdQuery { Id = id });
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CrearVacante(CreateVacanteCommand request)
        {
            await Mediator.Send(request);
            return RedirectToAction(nameof(Profile), new { id = request.EmpleadorId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id)
        {
            var response = await Mediator.Send(new GetEmpleadorByIdQuery { Id = id });
            var industrias = await Mediator.Send(new GetIndustriasQuery());
            ViewBag.Industrias = industrias.Data;
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UpdateEmpleadorCommand request)
        {
            _ = await Mediator.Send(request);
            return RedirectToAction(nameof(Profile), new { id = request.UsuarioId });
        }
    }
}
