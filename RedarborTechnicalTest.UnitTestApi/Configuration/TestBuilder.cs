using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
    }
}
