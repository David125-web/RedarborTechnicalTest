using AutoMapper;
using FluentValidation;
using MediatR;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Exceptions;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Querys;
using System.Net;

namespace RedarborTechnicalTest.Core.Services.EventHandlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEntity> _employeeRepository; 
        private readonly IEnumerable<IValidator<GetEmployeeQuery>> _validators;

        public GetEmployeeHandler(IMapper mapper,
            IRepository<EmployeeEntity> employeeRepository,
            IEnumerable<IValidator<GetEmployeeQuery>> validators)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _validators = validators;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll();
            if (employees.Count() == 0) throw new BusinessException() { CodeResponse = HttpStatusCode.NotFound, ErrorMessage = $"No se encontro ningun empleado." };
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
