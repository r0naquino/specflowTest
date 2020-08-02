using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.PageModel
{
    public class ShoppingCartPage: BasePage
    {
        IWebDriver driver;
        public ShoppingCartPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }
    }
}
