using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Exceptions;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.Core.Wrappers;
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
            HttpResponseMessage response = null;
            try
            {
                int idEmployee = 20;
                response = this.TestClient.GetAsync($"api/redarbor/{idEmployee}").Result;
                response.EnsureSuccessStatusCode();

                var employee = await this.TestClient.GetAsync($"api/redarbor/{idEmployee}");
                employee.EnsureSuccessStatusCode();
                Assert.True(false, $"Empleado con id {idEmployee} no existe.");
            }
            catch (Exception)
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
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
                Username = "david02"
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


        }
        [Fact]
        public async Task DeleteEmployeeSuccess()
        {
            int idEmployee = 9;
            try
            {
                var response =await this.TestClient.DeleteAsync($"api/redarbor/{idEmployee}");
                response.EnsureSuccessStatusCode();
                Assert.True(true, $"Empleado con id {idEmployee} eliminado.");
            }
            catch (Exception)
            {
                throw new Exception($"Empleado con id {idEmployee} no existe.");
            }
        }
    }
}