using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Slugify.Services;

namespace Slugify.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IConvertService _convertService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IConvertService convertService)
    {
        _convertService = convertService;
        _logger = logger;
    }

    [Route("convert-url")]
    [HttpGet]
    public Task<string> ConvertUrl(string item)
    {
        if (string.IsNullOrEmpty(item)) return Task.FromResult("Item is empty");

        return _convertService.ConvertSlugify(item, true, true);
    }

    [Route("convert-uppercase")]
    [HttpGet]
    public Task<string> ConvertUpperCase(string item, string culture)
    {
        if (string.IsNullOrEmpty(item)) return Task.FromResult("Item is empty");

        var cultureInfo = CreateCultureInfo(culture);

        return _convertService.ConvertUpperCase(item, cultureInfo);
    }

    [Route("convert-lowercase")]
    [HttpGet]
    public Task<string> ConvertLowerCase(string item, string culture)
    {
        if (string.IsNullOrEmpty(item)) return Task.FromResult("Item is empty");

        var cultureInfo = CreateCultureInfo(culture);

        return _convertService.ConvertLowerCase(item, cultureInfo);
    }

    [Route("convert-capitalizedcase")]
    [HttpGet]
    public Task<string> ConvertCapitalizedCase(string item, string culture)
    {
        if (string.IsNullOrEmpty(item)) return Task.FromResult("Item is empty");

        var cultureInfo = CreateCultureInfo(culture);

        return _convertService.ConvertCapitalizedCase(item, cultureInfo);
    }

    private CultureInfo CreateCultureInfo(string culture)
    {
        try
        {
            return new CultureInfo(culture);
        }
        catch (CultureNotFoundException)
        {
            //if not find any culture, use invariant culture
            return CultureInfo.InvariantCulture;
        }
    }
}