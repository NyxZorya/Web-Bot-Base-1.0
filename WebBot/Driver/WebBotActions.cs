using OpenQA.Selenium;
using WebBot.Utilities;

namespace WebBot.Driver
{
    public class WebBotActions
    {

        Logger _logger = Logger.Instance;

        public void EnterText(IWebElement Element, string TextToEnter)
        {
            _logger.AddLogItem($"\t └Entering Text \"{TextToEnter}\"");

            Element.SendKeys(TextToEnter);
        }

        public void Click(IWebElement Element)
        {
            _logger.AddLogItem($"\t └Clicking");

            Element.Click();
        }

    }
}
