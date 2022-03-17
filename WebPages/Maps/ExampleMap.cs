using OpenQA.Selenium;
using WebBot.Enums;

namespace WebPages.Maps
{
    public class ExampleMap : MapBase
    {

        public IWebElement SearchTextBox => _driver.FindWaitForElement("Search Text Box", SearchByEnum.XPath, "//*[@id=\"gh-search-input\"]");

        public IWebElement SearchButton  => _driver.FindWaitForElement("Search Button", SearchByEnum.XPath, "//button[contains(@class, 'header-search-button')]");

    }
}
