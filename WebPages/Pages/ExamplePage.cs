using WebPages.Actions;

namespace WebPages.Pages
{
    public class ExamplePage
    {

        private ExampleActions _actions = new ExampleActions();

        public void SearchForProduct(string ProductName)
        {
            _actions.EnterSearchText(ProductName);

            _actions.ClickSearchButton();
        }

    }
}
