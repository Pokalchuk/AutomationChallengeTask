using AutomationChallengeTask.Extensions;
using OpenQA.Selenium;

namespace AutomationChallengeTask.Pages;

public class GoogleHomePage(IWebDriver driver)
{
    private readonly IWebDriver _driver = driver;

    private readonly By SearchFieldLocator = By.Name("q");
    private const string GOOGLE_URL = "https://www.google.com";

    public void Open()
    {
        _driver.Navigate().GoToUrl(GOOGLE_URL);
    }

    public bool IsSearchFieldEnabled()
    {
        return _driver.IsElementEnabled(SearchFieldLocator);
    }

    public void Search(string text)
    {
        var searchField = _driver.FindElementWithWait(SearchFieldLocator);
        searchField.Clear();
        searchField.SendKeys(text);
        searchField.SendKeys(Keys.Enter);
    }
}
