using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Exceptions;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Querys;
using System.Net;

namespace RedarborTechnicalTest.Core.Services.EventHandlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        private readonly IEnumerable<IValidator<GetEmployeeByIdQuery>> _validators;

        public GetEmployeeByIdHandler(IMapper mapper,
            IRepository<EmployeeEntity> employeeRepository,
            IEnumerable<IValidator<GetEmployeeByIdQuery>> validators)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _validators = validators;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetById(query.id);
            if(employees == null) throw new BusinessException() { CodeResponse = HttpStatusCode.NotFound, ErrorMessage = $"Empleado con id {query.id} no existe." };
            return _mapper.Map<EmployeeDto>(employees);
        }
    }
}
