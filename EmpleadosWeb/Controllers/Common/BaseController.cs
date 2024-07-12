using Application.DTOs;
using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace EmpleadosWeb.Controllers.Common
{
    public abstract class BaseController : Controller
    {
        protected IMediator Mediator;
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
            //var userString = HttpContext.Session.GetString("userinfo");
            //var userWrapper = string.IsNullOrEmpty(userString) ? null : JsonConvert.DeserializeObject<WrapperResponse<UsuarioDto>>(userString);
            //var user = userWrapper?.Data;
            //ViewBag.User = user;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var userString = HttpContext.Session.GetString("userinfo");
            var userWrapper = string.IsNullOrEmpty(userString) ? null : JsonConvert.DeserializeObject<WrapperResponse<UsuarioDto>>(userString);
            var user = userWrapper?.Data;
            ViewBag.User = user;
        }
    }
}
