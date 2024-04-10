using System.Globalization;
using Slugify.Services;

namespace CaseConverter.Test;

[TestFixture]
public class ConvertServiceTests
{
    private ConvertService _convertService;

    [SetUp]
    public void Setup()
    {
        _convertService = new ConvertService();
    }

    [Test]
    public async Task ConvertSlugify_ReturnsExpectedSlug_WhenGivenValidName()
    {
        var result = await _convertService.ConvertSlugify("Şehir Üniversitesi", true, true);
        Assert.That(result, Is.EqualTo("sehir-universitesi"));
    }
    
    [Test]
    public async Task ConvertUpperCase_ReturnsUpperCase_WhenGivenLowerCase()
    {
        var result = await _convertService.ConvertUpperCase("İçErİK", CultureInfo.InvariantCulture);
        Assert.That(result, Is.EqualTo("İÇERİK"));
    }

    [Test]
    public async Task ConvertLowerCase_ReturnsLowerCase_WhenGivenUpperCase()
    {
        var result = await _convertService.ConvertLowerCase("çAlıŞmA", CultureInfo.InvariantCulture);
        Assert.That(result, Is.EqualTo("çalışma"));
    }

    [Test]
    public async Task ConvertCapitalizedCase_ReturnsCapitalizedCase_WhenGivenLowerCase()
    {
        var result = await _convertService.ConvertCapitalizedCase("şEhir üniveRSiteSi", CultureInfo.InvariantCulture);
        Assert.That(result, Is.EqualTo("Şehir Üniversitesi"));
    }
}