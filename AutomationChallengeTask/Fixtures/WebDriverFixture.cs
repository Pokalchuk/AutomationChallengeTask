using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationChallengeTask.Fixtures;

public class WebDriverFixture : IDisposable
{
    private readonly Lazy<IWebDriver> _lazyDriver;

    public WebDriverFixture()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        options.AddArgument("--disable-gpu");

        _lazyDriver = new Lazy<IWebDriver>(() => new ChromeDriver(options));
    }

    public IWebDriver Driver => _lazyDriver.Value;

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
