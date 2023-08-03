using Microsoft.EntityFrameworkCore;
using RedarborTechnicalTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.UnitTestApi.Configuration
{
    public static class ApplicationDbContextInMemory
    {
        public static ApplicationEmployeeDbContext Get()
        { 
        var options = new DbContextOptionsBuilder<ApplicationEmployeeDbContext>()
                .UseInMemoryDatabase(databaseName:$"Employee.Db")
                .Options;

            return new ApplicationEmployeeDbContext(options);
        }
    }
}
