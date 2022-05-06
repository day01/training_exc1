using OpenQA.Selenium;
using Xunit;

namespace OponeoBehavior.Specs.PageObjects;

public class OponeoMotorPageObject
{
    private IWebDriver _driver;

    public OponeoMotorPageObject(IWebDriver driver)
    {
        _driver = driver;
    }

    public string GetTitle()
    {
        return _driver.Title;
    }
}