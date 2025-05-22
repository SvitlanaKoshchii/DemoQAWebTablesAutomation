using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQAWebTablesAutomation.Helpers
{
    public static class WaitHelpers
    {
        public static void WaitForTableRowData(IWebDriver driver, string value, int timeoutSeconds = 10) {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(drv =>
                drv.FindElements(By.XPath("//div[@role='rowgroup']/div"))
                   .Any(r => r.Text.Contains(value)));
        }

        public static void WaitForTableRowDeletion(IWebDriver driver, string value, int timeoutSeconds = 10) {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => {
                try {
                    var matchingRows = d.FindElements(By.XPath("//div[@role='rowgroup']/div"))
                        .Where(row => row.Text.Contains(value))
                        .ToList();

                    if (matchingRows.Count > 0) {
                        Console.WriteLine($"[DEBUG] Still found {matchingRows.Count} row(s) containing: {value}");
                        return false;
                    }

                    return true;
                }
                catch (StaleElementReferenceException) {
                    return true; // Consider deleted
                }
                catch (NoSuchElementException) {
                    return true; // Consider NOT deleted
                }
            });
        }
    }
}