using NUnit.Framework;
using DemoQAWebTablesAutomation.Pages;
using DemoQAWebTablesAutomation.Helpers;

namespace DemoQAWebTablesAutomation.Tests { 
    public class DemoQATest : DemoQATestBase {
        private WebTablesPage page;

        [Test]
        public void FullWebTableFlow() {
            page = new WebTablesPage(driver);

            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            ScreenshotHelper.CaptureScreenshot(driver, "01_Navigate");

            // Add User
            page.AddButton.Click();
            page.FirstName.SendKeys(testData.User.FirstName);
            page.LastName.SendKeys(testData.User.LastName);
            page.Email.SendKeys(testData.User.Email);
            page.Age.SendKeys(testData.User.Age.ToString());
            page.Salary.SendKeys(testData.User.Salary.ToString());
            page.Department.SendKeys(testData.User.Department);
            page.SubmitButton.Click();
            ScreenshotHelper.CaptureScreenshot(driver, "02_Add_User");

            WaitHelpers.WaitForTableRowData(driver, testData.User.FirstName);
            Assert.IsTrue(page.IsUserPresent(testData.User.FirstName), "User was not added");
            ScreenshotHelper.CaptureScreenshot(driver, "03_Verify_Add");

            // Edit Salary
            page.clickEditButtonForEmail(testData.User.Email);
            page.Salary.Clear();
            page.Salary.SendKeys(testData.UpdatedSalary.ToString());
            page.SubmitButton.Click();
            ScreenshotHelper.CaptureScreenshot(driver, "04_Edit_Salary");

            WaitHelpers.WaitForTableRowData(driver, testData.UpdatedSalary.ToString());
            Assert.IsTrue(page.IsUserPresent(testData.UpdatedSalary.ToString()), "Salary was not updated");
            ScreenshotHelper.CaptureScreenshot(driver, "05_Verify_Salary");

            // Delete User
            page.clickDeleteButtonForEmail(testData.User.Email);
            ScreenshotHelper.CaptureScreenshot(driver, "06_Delete_User");

            WaitHelpers.WaitForTableRowDeletion(driver, testData.User.Email);
            Assert.IsFalse(page.IsUserPresent(testData.User.Email), "User was not deleted");
            ScreenshotHelper.CaptureScreenshot(driver, "07_Verify_Delete");
        }
    }
}
