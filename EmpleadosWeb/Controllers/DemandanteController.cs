using Application.Features.Demandantes.Commands.Create;
using Application.Features.Demandantes.Commands.Update;
using Application.Features.Demandantes.Queries.GetDemandanteById;
using Application.Features.ExperienciasLaborales.Commands.Create;
using Application.Features.ExperienciasLaborales.Commands.Delete;
using Application.Features.NivelesEducativos.Queries.GetNivelesEducativos;
using EmpleadosWeb.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosWeb.Controllers
{
    public class DemandanteController(IMediator mediator) : BaseController(mediator)
    {
        public async Task<IActionResult> Profile(long id)
        {
            var response = await Mediator.Send(new GetDemandanteByIdQuery { Id = id });
            return View(response.Data);
        }

        public async Task<IActionResult> Crear()
        {
            var nivelesEducativos = await Mediator.Send(new GetNivelesEducativosQuery());
            ViewBag.NivelesEducativos = nivelesEducativos.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CreateDemandanteCommand request)
        {
            var response = await Mediator.Send(request);
            return RedirectToAction(nameof(Profile), new { id = response.Data.UsuarioId });
        }


        [HttpPost]
        public async Task<IActionResult> EliminarExperiencia(long demandanteId, long experienciaId)
        {
            var response = await Mediator.Send(new GetDemandanteByIdQuery { Id = demandanteId });
            ViewBag.Demandante = response.Data;
            await Mediator.Send(new DeleteExperienciaLaboralCommand { Id = experienciaId });
            return RedirectToAction(nameof(Profile), new { id = demandanteId });
        }


        [HttpGet]
        public async Task<IActionResult> CrearExperiencia(long id)
        {
            var response = await Mediator.Send(new GetDemandanteByIdQuery { Id = id });
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CrearExperiencia(CreateExperienciaLaboralCommand request)
        {
            await Mediator.Send(request);
            return RedirectToAction(nameof(Profile), new { id = request.DemandanteId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id)
        {
            var response = await Mediator.Send(new GetDemandanteByIdQuery { Id = id });
            var nivelesEducativos = await Mediator.Send(new GetNivelesEducativosQuery());
            ViewBag.NivelesEducativos = nivelesEducativos.Data;
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UpdateDemandanteCommand request)
        {
            _ = await Mediator.Send(request);
            return RedirectToAction(nameof(Profile), new { id = request.UsuarioId });
        }
    }
}
