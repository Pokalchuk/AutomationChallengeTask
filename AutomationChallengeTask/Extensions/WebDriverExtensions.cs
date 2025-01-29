using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationChallengeTask.Extensions;

public static class WebDriverExtensions
{
    public static IWebElement FindElementWithWait(this IWebDriver driver, By locator, TimeSpan? timeout = null)
    {
        var wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(5));
        try
        {
            return wait.Until(drv => drv.FindElement(locator));
        }
        catch (WebDriverTimeoutException)
        {
            throw new NoSuchElementException($"Element with locator: '{locator}' was not found after {timeout?.TotalSeconds ?? 5} seconds.");
        }
    }

    public static bool IsElementDisplayed(this IWebDriver driver, By locator, TimeSpan? timeout = null)
    {
        var wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(5));
        try
        {
            return wait.Until(drv =>
            {
                IWebElement? element = null;

                try
                {
                    element = drv.FindElement(locator);
                }
                catch
                {
                    return false;
                }

                return element != null && element.Displayed;
            });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public static bool IsElementEnabled(this IWebDriver driver, By locator, TimeSpan? timeout = null)
    {
        var wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(5));
        try
        {
            return wait.Until(drv =>
            {
                IWebElement? element = null;

                try
                {
                    element = drv.FindElement(locator);
                }
                catch
                {
                    return false;
                }

                return element != null && element.Enabled;
            });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}