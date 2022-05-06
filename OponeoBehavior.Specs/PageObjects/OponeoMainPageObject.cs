using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace OponeoBehavior.Specs.PageObjects;

public class OponeoMainPageObject
{
    private readonly IWebDriver _driver;

    public OponeoMainPageObject(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement SearchByCar =>
        _driver.FindElement(By.XPath("//*[@id=\"_carTires_ctTS_upSH\"]/div/div/ul/li[2]/a"));

    private SelectElement SelectMarkElement =>
        new SelectElement(_driver.FindElement(By.XPath("//*[@id=\"_ctCS_carSelCT_ddlCarMark\"]")));

    private SelectElement SelectModelElement =>
        new SelectElement(_driver.FindElement(By.XPath("//*[@id=\"_ctCS_carSelCT_ddlCarModel\"]")));

    private IWebElement ToUpElement => _driver.FindElement(By.XPath("//*[@id=\"scrollTop\"]"));

    private IWebElement LinkToSubPages =>
        _driver.FindElement(By.XPath("//*[@id=\"form1\"]/header/nav/div[1]/div[1]/span"));

    private IWebElement LinkMotorPage =>
        _driver.FindElement(By.XPath("//*[@id=\"form1\"]/header/nav/div[1]/div[1]/div/div[1]/a[2]"));

    public void ScrollToDownOfAPage()
    {
        _driver.ExecuteJavaScript("window.scrollTo(0, document.body.scrollHeight);");
    }

    public void ClickCarSearch()
    {
        SearchByCar.Click();
    }

    public bool CheckBottomIsDisplayed()
    {
        return ToUpElement.Displayed;
    }

    public void SelectMark(string mark)
    {
        SelectMarkElement.SelectByText(mark);
    }

    public void SelectModel(string model)
    {
        SelectModelElement.SelectByText(model);
    }

    public string GetMark()
    {
        return SelectMarkElement.SelectedOption.Text;
    }

    public string GetModel()
    {
        return SelectModelElement.SelectedOption.Text;
    }

    public void OpenSubPagesManu()
    {
        LinkToSubPages.Click();
    }
    
    public void GoToMotorPage()
    {
        LinkMotorPage.Click();
    }
}