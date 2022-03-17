using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebBot.Enums;
using WebBot.Utilities;

namespace WebBot.Driver
{
    public class WebBotDriver
    {

        // *** Class must follow Singleton Pattern ***

        private ChromeDriver _driver;
        private Logger _logger;

        private static WebBotDriver _instance;

        public static WebBotDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WebBotDriver();
                }

                return _instance;
            }
        }

        private WebBotDriver()
        {
            _logger = Logger.Instance;
            _logger.AddLogItem($"Creating BotDriver and setting up browser ...");

            ChromeOptions Options = new ChromeOptions();
            Options.AddArgument("--headless");

            _driver = new ChromeDriver("..\\..\\..\\..\\ChromeDriver");
            //_driver = new ChromeDriver("..\\..\\..\\..\\ChromeDriver", Options);
            _driver.Manage().Window.Maximize();
        }

        public void NavigateTo(string URL)
        {
            _logger.AddLogItem($"Navigating to {URL} ...");

            _driver.Navigate().GoToUrl(URL);
        }

        public void ForceClose()
        {
            List<string> ProcessesToKill = new List<string>();
            ProcessesToKill.Add("chrome");

            foreach (Process CurrentProcess in Process.GetProcesses())
            {
                foreach (string ProcessToKill in ProcessesToKill)
                {
                    if (CurrentProcess.ProcessName.ToLower().Contains(ProcessToKill))
                    {
                        try
                        {
                            CurrentProcess.Kill();
                            CurrentProcess.Close();
                            CurrentProcess.Dispose();
                        }
                        catch
                        {
                            // Do nothing
                        }
                    }
                }
            }
        }

        public IWebElement FindElement(string ElementName, SearchByEnum SearchBy, string ElementSearchString)
        {
            _logger.AddLogItem($"Locating Element: {ElementName}");

            try
            {
                switch (SearchBy)
                {
                    case SearchByEnum.XPath:
                        return _driver.FindElement(By.XPath(ElementSearchString));
                    case SearchByEnum.Id:
                        return _driver.FindElement(By.Id(ElementSearchString));
                    default:
                        throw new System.Exception($"\nUnable to Search By: {SearchBy}");
                }
            }
            catch
            {
                throw new System.Exception($"\nUnable to locate: {ElementName}");
            }
        }

        public IWebElement FindWaitForElement(string ElementName, SearchByEnum SearchBy, string ElementSearchString)
        {
            int MaxTries = 10;

            for (int i = 0; i < MaxTries; i++)
            {
                try
                {
                    return this.FindElement(ElementName, SearchBy, ElementSearchString);
                }
                catch (Exception E)
                {
                    if (!E.Message.Contains("Unable to locate:"))
                    {
                        throw;
                    }

                    if (i == MaxTries - 1)
                    {
                        break;
                    }

                    Thread.Sleep(1000);
                }
            }

            _logger.AddLogItem($"\nFailed while attempting to locate: {ElementName}\n\t{SearchBy}:{ElementSearchString}");

            throw new System.Exception($"\nUnable to locate: {ElementName} after {MaxTries} seconds / retries.");
        }

    }
}
