namespace WebBot.Utilities
{
    public class Logger
    {

        // ** Class must follow Singleton Pattern ***

        private static Logger _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        private List<string> LogItems;

        private Logger()
        {
            LogItems = new List<string>();
        }

        public void AddLogItem(string LogItem)
        {
            LogItems.Add(LogItem);
        }

        public void WriteLogToFile()
        {
            string FilePath = @"C:\\AutomationDumps\" + DateTime.Now.ToString("MMddyyyy hh mm ss") + ".txt";

            try
            {
                StreamWriter FileWriter = new StreamWriter(FilePath);

                foreach (string LogItem in this.LogItems)
                {
                    FileWriter.WriteLine(LogItem);
                }

                FileWriter.Close();
            }
            catch
            {
                throw new System.Exception("\nCreate a folder on your C drive called 'AutomationDumps'");
            }
        }

    }
}
