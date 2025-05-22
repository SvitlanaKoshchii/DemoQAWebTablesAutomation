using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoQAWebTablesAutomation.Models;

namespace DemoQAWebTablesAutomation.Tests {
    public class DemoQATestBase {
        protected IWebDriver driver;
        protected TestInput testData;

        [SetUp]
        public void SetUp() {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            var json = File.ReadAllText("TestData/userData.json");
            testData = JsonConvert.DeserializeObject<TestInput>(json);
        }

        [TearDown]
        public void TearDown() {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
