
using System.Reflection.Metadata;

namespace RedarborTechnicalTest.Api.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public static class EmployeeRoutes
        {
            public const string GetEmployee = Root + "/redarbor";
            public const string GetEmployeeById = Root + "/redarbor/{id}";
            public const string AddEmployee = Root + "/redarbor";
            public const string UpdateEmployee = Root + "/redarbor/{id}";
            public const string DeleteEmployee = Root + "/redarbor/{id}";

        }
    }
}
