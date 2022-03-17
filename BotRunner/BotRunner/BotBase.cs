using WebBot.Driver;
using WebBot.Utilities;
using WebPages.Pages;

namespace BotRunner.BotRunner
{
    public class BotBase
    {

        protected Logger _logger = Logger.Instance;
        protected WebBotDriver _webBot = WebBotDriver.Instance;

        // Pages
        protected ExamplePage _examplePage = new ExamplePage();

    }
}
