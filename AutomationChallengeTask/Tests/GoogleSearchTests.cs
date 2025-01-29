using AutomationChallengeTask.Fixtures;
using AutomationChallengeTask.Pages;

namespace AutomationChallengeTask.Tests;

public class GoogleSearchTests(WebDriverFixture fixture) : IClassFixture<WebDriverFixture>
{
    private readonly GoogleHomePage _homePage = new(fixture.Driver);
    private readonly GoogleSearchResultsPage _resultsPage = new(fixture.Driver);

    // NOTE: I'm not using soft assert here because if a previous Assert fails, 
    // the test should fail immediately and no further logic needs to be checked.
    [Fact]
    public void GoogleSearch_VerifySearchResultsContainKeyword()
    {
        var inputText = "Selenium C# tutorial";
        var expectedSubstring = "Selenium.";
        int firstPosition = 1;

        _homePage.Open();
        Assert.True(_homePage.IsSearchFieldEnabled(), "Search field is not enabled.");

        _homePage.Search(inputText);
        Assert.True(_resultsPage.AreResultsDisplayed(), "Search results are not displayed.");

        string firstResultTitle = _resultsPage.GetResultTitleByPosition(firstPosition);
        Assert.Contains(expectedSubstring, firstResultTitle);
    }
}
