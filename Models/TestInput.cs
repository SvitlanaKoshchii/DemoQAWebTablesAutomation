namespace DemoQAWebTablesAutomation.Models {
    public class TestInput {
        public UserData User { get; set; }
        public int UpdatedSalary { get; set; }
    }

    public class UserData {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }
}

