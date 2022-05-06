using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using OponeoBehavior.Specs.Drivers;
using TechTalk.SpecFlow;

namespace OponeoBehavior.Specs.Hooks;

[Binding]
public sealed class HookInitialization
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IObjectContainer _objectContainer;

    public HookInitialization(ScenarioContext scenarioContext, IObjectContainer objectContainer)
    {
        _scenarioContext = scenarioContext;
        _objectContainer = objectContainer;
    }
    
    [BeforeScenario]
    public void BeforeScenario(SeleniumDriver driver)
    {
        _objectContainer.RegisterInstanceAs(driver.CurrentDriver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }
}