namespace Application.Contracts.Services.HttpServices
{
    public interface ICookieService
    {
        T GetCookie<T>(string key);
        void SetCookie<T>(string key, T value, int? expireTime = null);
        void RemoveCookie(string key);
    }
}
