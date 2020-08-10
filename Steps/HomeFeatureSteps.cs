using OpenQA.Selenium;
using SpecFlowProject.PageModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class HomeFeatureSteps
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;
        private HomePage homePage;

        public HomeFeatureSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
        
        [When(@"the user add (.*) item to cart")]
        public void WhenTheUserAddItemToCart(string itemName)
        {
            homePage = scenarioContext.Get<HomePage>("home");
            homePage.AddItemToCart(itemName);
        }
        
        [Then(@"the shopping cart icon badge will display (.*) as number of items in cart")]
        public void ThenTheShoppingBagIconBadgeWillDisplayItem(int noOfItems)
        {
            homePage.VerifyNumberOfItemsInCart(noOfItems);
        }
    }
}
