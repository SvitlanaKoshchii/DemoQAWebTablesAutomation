using OpenQA.Selenium;

namespace DemoQAWebTablesAutomation.Helpers {
    public static class ScreenshotHelper {
        private const string ScreenshotsFolderName = "Screenshots";

        public static void CaptureScreenshot(IWebDriver driver, string testStepName) {
            try {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ScreenshotsFolderName);

                if (!Directory.Exists(screenshotsDir)) {
                    Directory.CreateDirectory(screenshotsDir);
                }

                string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{testStepName}.png";
                string filePath = Path.Combine(screenshotsDir, fileName);

                screenshot.SaveAsFile(filePath); 
            }
            catch (Exception ex) {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
}
