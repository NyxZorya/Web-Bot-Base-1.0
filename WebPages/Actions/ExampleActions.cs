using WebBot.Driver;
using WebBot.Utilities;
using WebPages.Maps;

namespace WebPages.Actions
{
    public class ExampleActions
    {

        private ExampleMap _map = new ExampleMap();

        private WebBotActions _actions = new WebBotActions();

        public void EnterSearchText(string SearchText)
        {
            _actions.EnterText(_map.SearchTextBox, SearchText);
        }

        public void ClickSearchButton()
        {
            _actions.Click(_map.SearchButton);
        }

    }
}
