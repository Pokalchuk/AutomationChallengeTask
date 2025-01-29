using AutomationChallengeTask.Extensions;
using OpenQA.Selenium;

namespace AutomationChallengeTask.Pages;

public class GoogleSearchResultsPage(IWebDriver driver)
{
    private readonly IWebDriver _driver = driver;

    private By SearchResultGridLocator = By.Id("search");
    private By ResultTitleLocator = By.XPath($"//h3");

    private IWebElement SearchResultGrid => _driver.FindElementWithWait(SearchResultGridLocator);

    public bool AreResultsDisplayed()
    {
        return SearchResultGrid.Displayed;
    }

    public string GetResultTitleByPosition(int resultPosition)
    {
        if (resultPosition < 1)
        {
            throw new ArgumentException("Index must be greater than or equal to 1.");
        }

        var resultTitles = SearchResultGrid.FindElements(ResultTitleLocator);
        return resultTitles[resultPosition - 1].Text;
    }
}
