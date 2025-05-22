# DemoQA WebTables Automation

This project is a **.NET Core Console Application** using **Selenium WebDriver** to automate interactions with the [Web Tables page on DemoQA](https://demoqa.com/webtables).  
It reads test user data from a JSON file, performs CRUD-like operations (Create, Update, Delete), and captures **screenshots** at each key step.

## Project Structure

```text
DemoQAWebTablesAutomation/
├── Pages/
│   └── WebTablesPage.cs          # Page Object Model for the Web Tables page
├── Helpers/
│   ├── ScreenshotHelper.cs       # Captures screenshots
│   └── WaitHelpers.cs            # Custom wait utilities
├── Models/
│   └── TestInput.cs              # Root object for JSON input, contains UserData and UpdatedSalary
├── TestData/
│   └── userData.json             # Sample test data (user info and updated salary)
├── Tests/
│   ├── DemoQATest.cs             # Main test class that performs the full Web Tables interaction
│   └── DemoQATestBase.cs         # Base test class containing setup and teardown logic
├── DemoQAWebTablesAutomation.csproj
└── README.md
```

## Test Flow Overview
1. Navigate to the [Web Tables](https://demoqa.com/webtables) page.
2. Add a new row by clicking the "Add" button.
3. Fill out the form using values from `userData.json`
4. Click "Submit" to save the data.
5. Wait for the new row to appear in the table, using `WaitForTableRowData`.
6. Verify that the row with the inserted name is in the table.
7. Edit the row, change the salary to a different amount and submit the form again.
8. Wait for the updated data in the table, using `WaitForTableRowData`.
9. Verify that the new salary is now in the table.
10. Delete the row and ensure it's deleted by using the `WaitForTableRowDeletion`.
11. Verify that the row no longer exists in the table.

##  Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed (version 8.0 or compatible)
- **Google Chrome** browser installed 
- **ChromeDriver** installed and on your system PATH. Alternatively, update the project to use WebDriverManager for .NET

#### Cloning the Repository
Clone the repository excuting command: 
```bash
git clone
```

#### Running the Test
Execute this command from the project root folder (where `DemoQAWebTablesAutomation.csproj` is located):
```bash
dotnet test
```
Test output and screenshots will be generated after the run.

#### Screenshots
All screenshots are saved in the /Screenshots/ folder under the project root.
Each image is named to reflect the step it was captured at:
- `01_Navigate.png`
- `04_Edit.png`
- `07_Verify_Delete.png`
etc.

#### Sample JSON Format (userData.json)

```json
{
  "user": {
    "firstName": "Siena",
    "lastName": "Riley",
    "email": "siena.riley@test.com",
    "age": 34,
    "salary": 40000,
    "department": "QA Engineer"
  },
  "updatedSalary": 45000
}

