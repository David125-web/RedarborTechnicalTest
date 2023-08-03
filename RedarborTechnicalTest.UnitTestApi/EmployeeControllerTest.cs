using AutoMapper;
using FluentValidation;
using Moq;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.Core.Services.EventHandlers;
using RedarborTechnicalTest.Core.Services.Querys;
using RedarborTechnicalTest.Infrastructure.Repositories;
using RedarborTechnicalTest.UnitTestApi.Configuration;

namespace RedarborTechnicalTest.UnitTestApi
{
    public class EmployeeControllerTest
    {
        
        //private IMapper _mapper
        //{
        //    get
        //    {
        //        return new Mock<IMapper>()
        //            .Object;
        //    }
        //}
        //private IEnumerable<IValidator<GetEmployeeByIdQuery>> _validators
        //{
        //    get
        //    {
        //        return new Mock<IEnumerable<IValidator<GetEmployeeByIdQuery>>>()
        //            .Object;
        //    }
        //}
        //private IEnumerable<IValidator<GetEmployeeQuery>> _validators2
        //{
        //    get
        //    {
        //        return new Mock<IEnumerable<IValidator<GetEmployeeQuery>>>()
        //            .Object;
        //    }
        //}
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        public EmployeeControllerTest()
        {
            var context = ApplicationDbContextInMemory.Get();
            _employeeRepository = new GenericRepository<EmployeeEntity>(context);
        }
        [Fact]
        public async void GetEmployeeSuccess()
        {
            var result = await _employeeRepository.GetAll();
            var employees = Assert.IsType<IEnumerable<EmployeeEntity>>(result);
            Assert.True(employees.Count() > 0);

        }

    //    [Fact]
    //    public void GetEmplojyeeSuccess()
    //    {
    //        var entity = new EmployeeEntity
    //        {
    //            Id = 1,
    //            CompanyId = 0,
    //            CreatedOn = DateTime.Now,
    //            DeletedOn = DateTime.Now,
    //            Email = "string",
    //            Fax = "string",
    //            Name = "string",
    //            Lastlogin = DateTime.Now,
    //            Password = "string",
    //            PortalId = 0,
    //            RoleId = 0,
    //            StatusId = true,
    //            Telephone = "string",
    //            UpdatedOn = DateTime.Now,
    //            Username = "hermano prueba"
    //        };
    //        _employeeRepository.Add(entity);
    //        var handler = new GetEmployeeHandler(_mapper, _employeeRepository, _validators2);
    //        var valor = handler.Handle(new GetEmployeeQuery(), new CancellationToken()).Result;
    //        Assert.NotNull(valor);
    //    }
    //    [Fact]
    //    public void GetEmployeeByIdSuccess()
    //    {
    //        var context = ApplicationDbContextInMemory.Get();
    //        context.Employees.Add(new EmployeeEntity
    //        {
    //            Id = 1,
    //            CompanyId = 0,
    //            CreatedOn = DateTime.Now,
    //            DeletedOn = DateTime.Now,
    //            Email = "string",
    //            Fax = "string",
    //            Name = "string",
    //            Lastlogin = DateTime.Now,
    //            Password = "string",
    //            PortalId = 0,
    //            RoleId = 0,
    //            StatusId = true,
    //            Telephone = "string",
    //            UpdatedOn = DateTime.Now,
    //            Username = "string"
    //        });
    //        context.SaveChanges();
    //        var handler = new GetEmployeeByIdHandler(_mapper, _employeeRepository, _validators);
    //        handler.Handle(new GetEmployeeByIdQuery(1), new CancellationToken()).Wait();
    //    }
    }
}