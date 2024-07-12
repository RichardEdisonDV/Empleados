using Application.Attributes.Services;
using Application.Contracts.Services.HttpServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Infrastructure.Services.HttpServices
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T GetCookie<T>(string key)
        {
            var value = _httpContextAccessor.HttpContext.Request.Cookies[key];
            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;

        }

        public void RemoveCookie(string key)
        {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
            //if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key))
            //{
            //}
        }

        public void SetCookie<T>(string key, T value, int? expireTime = null)
        {
            RemoveCookie(key);

            var options = new CookieOptions();
            if (expireTime.HasValue)
            {
                options.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                options.Expires = DateTime.Now.AddDays(1);
            }

            var stringValue = JsonSerializer.Serialize(value);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, stringValue, options);
        }
    }
}
