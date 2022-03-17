using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotRunner.BotRunner
{
    [TestClass]
    public class BotRunner : BotBase
    {

        [TestMethod]
        public void SearchForVideo()
        {

            try
            {

                _webBot.NavigateTo("https://www.bestbuy.com/");

                _examplePage.SearchForProduct("Nintendo Switch");

            }
            catch
            {
                throw;
            }
            finally
            {
                _webBot.ForceClose();

                _logger.WriteLogToFile();
            }

        }

    }
}
