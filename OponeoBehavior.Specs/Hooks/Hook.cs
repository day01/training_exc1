using System;
using BoDi;
using OponeoBehavior.Specs.Drivers;
using OponeoBehavior.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace OponeoBehavior.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine($"Before Scenario: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine($"Before Scenario: {_scenarioContext.ScenarioInfo.Title}");
        }
        
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer container)
        {
            var driver = container.BaseContainer.Resolve<SeleniumDriver>();
            var pageObject = new CalculatorPageObject(driver.CurrentDriver);
            
            pageObject.CheckCorrectUrl();
        }
    }
}