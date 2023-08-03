using FluentAssertions;
using Newtonsoft.Json;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.UnitTestApi.Configuration;
using System.Net;
using System.Net.Http.Formatting;

namespace RedarborTechnicalTest.UnitTestApi
{
    public class EmployeeControllerTest : TestBuilder

    {
        [Fact]
        public async Task GetEmployeeByIdSuccess()
        {
            //Si falla la prueba es porque esta encontrando un empleado existente.

            var employee = new CreateEmployeeCommand
            {
                CompanyId = 15,
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
            var employeeCreado = await this.TestClient.PostAsync("/api/redarbor", employee, new JsonMediaTypeFormatter());
            employeeCreado.EnsureSuccessStatusCode();
            var message = employeeCreado.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<EmployeeDto>(message);
            var idEmployee = result.Id;
            var employeeId = await this.TestClient.GetAsync($"api/redarbor/{idEmployee}");
            employeeId.EnsureSuccessStatusCode();
            var response = employeeId.Content.ReadAsStringAsync().Result;
            var responseInquiry = System.Text.Json.JsonSerializer.Deserialize<EmployeeDto>(response);
            Assert.NotNull(responseInquiry);
        }
        [Fact]
        public async Task GetEmployeeError()
        {
            //Si falla la prueba es porque esta encontrando un empleado existente.
            HttpResponseMessage response = null;
            try
            {
                int idEmployee = 1;
                response = await this.TestClient.GetAsync($"api/redarbor/{idEmployee}");
                response.EnsureSuccessStatusCode();
                Assert.True(false, $"Empleado con id {idEmployee} no existe.");
            }
            catch (Exception ex)
            {
                response?.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }
        [Fact]
        public async Task CreateEmployeeSuccess()
        {
            var employees = await this.TestClient.GetAsync($"api/redarbor");
            employees.EnsureSuccessStatusCode();
            var response = employees.Content.ReadAsStringAsync().Result;
            var responseInquiry = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<EmployeeDto>>(response);
            var employee = new CreateEmployeeCommand
            {
                CompanyId = 30,
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
                Username = "pruebadavid"
            };
            var employeeCreate = await this.TestClient.PostAsync("/api/redarbor", employee, new JsonMediaTypeFormatter());
            employeeCreate.EnsureSuccessStatusCode();

            var employeesTest2 = await this.TestClient.GetAsync($"api/redarbor");
            employeesTest2.EnsureSuccessStatusCode();
            var responseTest2 = employeesTest2.Content.ReadAsStringAsync().Result;
            var respuestaConsulta2 = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<EmployeeDto>>(responseTest2);
            Assert.True(respuestaConsulta2?.Count() == responseInquiry?.Count() + 1);
        }

        [Fact]
        public async Task UpdateEmployeeError()
        {
            int idEmployee = 1;
            try
            {
                var employee = new CreateEmployeeCommand
                {
                    CompanyId = 30,
                    CreatedOn = DateTime.Now,
                    DeletedOn = DateTime.Now,
                    Email = "Jennifer@hotmail.com",
                    Fax = "string",
                    Name = "string",
                    Lastlogin = DateTime.Now,
                    Password = "string",
                    PortalId = 0,
                    RoleId = 0,
                    StatusId = true,
                    Telephone = "string",
                    UpdatedOn = DateTime.Now,
                    Username = "JenniferRamirez"
                };
                var employeePut = await this.TestClient.PutAsync($"/api/redarbor/{idEmployee}", employee, new JsonMediaTypeFormatter());
                employeePut.EnsureSuccessStatusCode();

                var currentEmployee = await this.TestClient.GetAsync($"api/redarbor/{idEmployee}");
                currentEmployee.EnsureSuccessStatusCode();
                Assert.True(true, $"Empleado con id {idEmployee} Actualizado.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Empleado con id {idEmployee} no existe.");
            }
        }
        [Fact]
        public async Task DeleteEmployeeSuccess()
        {
            int idEmployee = 2;
            try
            {
                var response = await this.TestClient.DeleteAsync($"api/redarbor/{idEmployee}");
                response.EnsureSuccessStatusCode();
                Assert.True(true, $"Empleado con id {idEmployee} eliminado.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Empleado con id {idEmployee} no existe.");
            }
        }
    }
}