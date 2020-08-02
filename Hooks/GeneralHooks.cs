using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;

        public GeneralHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driver = new ChromeDriver();

        }

        [BeforeScenario]
        public void StartTest()
        {
            scenarioContext.Add("driver", driver);
        }

        [AfterScenario]
        public void EndTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                StringBuilder date = new StringBuilder(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                date.Replace("/", "_");
                date.Replace(":", "_");
                date.Replace(" ", "_");

                string testName = TestContext.CurrentContext.Test.MethodName;

                if (!Directory.Exists(@"C:\SeleniumScreenshot\FailedTests_" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_")))
                {
                    Directory.CreateDirectory(@"C:\SeleniumScreenshot\FailedTests_" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_"));
                }

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\SeleniumScreenshot\FailedTests_" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_") + @"\FailedTest_" + testName + "_" + date + ".png", ScreenshotImageFormat.Png);
            }

            this.driver.Close();
        }
    }
}
