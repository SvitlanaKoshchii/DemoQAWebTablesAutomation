using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQAWebTablesAutomation.Pages {
    public class WebTablesPage {
        private readonly IWebDriver driver;

        public WebTablesPage(IWebDriver webDriver) {
            driver = webDriver;
        }

        public IWebElement AddButton => driver.FindElement(By.Id("addNewRecordButton"));
        public IWebElement FirstName => driver.FindElement(By.Id("firstName"));
        public IWebElement LastName => driver.FindElement(By.Id("lastName"));
        public IWebElement Email => driver.FindElement(By.Id("userEmail"));
        public IWebElement Age => driver.FindElement(By.Id("age"));
        public IWebElement Salary => driver.FindElement(By.Id("salary"));
        public IWebElement Department => driver.FindElement(By.Id("department"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public IReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//div[@role='rowgroup']/div"));

        public void clickEditButtonForEmail(string email) {
            var editBtn = driver.FindElements(By.XPath($"//div[@role='row' and .//div[text()='{email}']]//span[@title='Edit']")).FirstOrDefault();

            if (editBtn == null)
                throw new Exception($"Edit button not found for email: {email}");

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", editBtn);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editBtn));

            editBtn.Click();
        }
        public void clickDeleteButtonForEmail(string email) {
            var deleteBtn = driver.FindElements(By.XPath($"//div[@role='row' and .//div[text()='{email}']]//span[@title='Delete']")).FirstOrDefault();

            if (deleteBtn == null)
                throw new Exception($"Delete button not found for email: {email}");

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", deleteBtn);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(deleteBtn));

            deleteBtn.Click();
        }

        public bool IsUserPresent(string value) {
            return Rows.Any(r => r.Text.Contains(value));
        }
    }
}
