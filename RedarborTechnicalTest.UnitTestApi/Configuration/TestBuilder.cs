using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RedarborTechnicalTest.Core.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.UnitTestApi.Configuration
{
    public abstract class TestBuilder
    {
        protected HttpClient TestClient;
        private bool Disposed;
        protected TestBuilder()
        {
            TestingSuite();
        }
        protected void TestingSuite()
        {
            Disposed = false;
            var appFactory = new WebApplicationFactory<Program>();
            TestClient = appFactory.CreateClient();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }
        protected static CreateEmployeeCommand UseEmployeeAutomatic()
        {
            return new CreateEmployeeCommand()
            {
                CompanyId = 1,
                CreatedOn = DateTime.Now,
                DeletedOn = DateTime.Now,
                Email = "string",
                Fax = "string",
                Name = "string",
                Lastlogin = DateTime.Now,
                Password = "string",
                PortalId = 0,
                RoleId = 0,
                StatusId = true,
                Telephone = "string",
                UpdatedOn = DateTime.Now,
                Username = "david01"
            };
        }
    }
}
