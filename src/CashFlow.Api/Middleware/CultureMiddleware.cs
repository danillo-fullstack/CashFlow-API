using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureInfo = new CultureInfo("en");
        
        if (!string.IsNullOrWhiteSpace(culture))
        {
            var cultureName = culture.Split(',')[0];
            cultureInfo = new CultureInfo(cultureName);
        }
        
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        
        await next(context);
    }
}
