using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OponeoBehavior.Specs.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private bool _isDisposed;
        
        private readonly Lazy<IWebDriver> _currentDriver;

        public SeleniumDriver()
        {
            _isDisposed = false;
            _currentDriver = new Lazy<IWebDriver>(CreateWebDriver);
        }
        
        public IWebDriver CurrentDriver => _currentDriver.Value;

        private IWebDriver CreateWebDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            return driver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            
            _currentDriver.Value.Dispose();
            
            _isDisposed = true;
        }
    }
}