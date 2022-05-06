using OpenQA.Selenium;
using OponeoBehavior.Specs.Drivers;
using OponeoBehavior.Specs.PageObjects;
using Xunit;

namespace OponeoBehavior.Specs.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly SeleniumDriver _seleniumDriver;
    private readonly IWebDriver _webDriver;
    private readonly CalculatorPageObject _calculatorPage;

    private const string OponeoMainPageUrl = "https://www.oponeo.pl/";

    public CalculatorStepDefinitions(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver,
        IWebDriver webDriver)
    {
        _scenarioContext = scenarioContext;
        _seleniumDriver = seleniumDriver;
        _webDriver = webDriver;
        _calculatorPage = new CalculatorPageObject(seleniumDriver.CurrentDriver);
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        _calculatorPage.SetFirstNumber(number);
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        _calculatorPage.SetSecondNumber(number);
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _calculatorPage.ClickAddButton();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.Equal(result, _calculatorPage.GetResult());
    }

    [When(@"reset the calculator")]
    public void WhenResetTheCalculator()
    {
        _calculatorPage.ClickResetButton();
    }

    [Then(@"the result should empty")]
    public void ThenTheResultShouldEmpty()
    {
        Assert.Null(_calculatorPage.GetResult());
    }

    [When(@"the two numbers are subtracted")]
    public void WhenTheTwoNumbersAreSubtracted()
    {
        // _calculator.SubtractTwoNumbers();

        Thread.Sleep(TimeSpan.FromSeconds(10));
    }

    [Given(@"Open main oponeo page")]
    public void GivenOpenMainOponeoPage()
    {
        _webDriver.Navigate().GoToUrl(OponeoMainPageUrl);
    }

    [When(@"Click at the car search")]
    public void WhenClickAtTheMarkSearch()
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.ClickCarSearch();
    }

    [When(@"scroll down of the page")]
    public void WhenScrollDownOfThePage()
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.ScrollToDownOfAPage();
    }

    [Then(@"Check the bottom of page is displayed")]
    public void ThenCheckTheBottomOfPageIsDisplayed()
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        var actual = oponeoMainPage.CheckBottomIsDisplayed();

        Assert.True(actual);
    }

    [When(@"wait to show result")]
    [Then(@"wait to show result")]
    public void WhenWaitToShowResult()
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }

    [When(@"Select Car mark as ""(.*)""")]
    public void WhenSelectCarMarkAs(string mark)
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.SelectMark(mark);
    }

    [When(@"Select model as ""(.*)""")]
    public void WhenSelectCarModelAs(string model)
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.SelectModel(model);
    }

    [Then(@"Mark is ""(.*)"" and model is ""(.*)""")]
    public void ThenMarkIsAndModelIs(string mark, string model)
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        var actualMark = oponeoMainPage.GetMark();
        var actualModel = oponeoMainPage.GetModel();

        Assert.Equal(mark, actualMark);
        Assert.Equal(model, actualModel);
    }

    [When(@"Click at the submenu")]
    public void WhenClickAtTheSubmenu()
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.OpenSubPagesManu();
    }

    [When(@"click at motor submenu")]
    public void WhenClickAtMotorSubmenu()
    {
        var oponeoMainPage = new OponeoMainPageObject(_webDriver);
        oponeoMainPage.GoToMotorPage();
    }

    [Then(@"the subpage is a motor page")]
    public void ThenTheSubpageIsAMotorPage()
    {
        var oponeoPage = new OponeoMotorPageObject(_webDriver);
        var title = oponeoPage.GetTitle();

        Assert.Equal("Opony Motocyklowe » Oponeo", title);
    }
}