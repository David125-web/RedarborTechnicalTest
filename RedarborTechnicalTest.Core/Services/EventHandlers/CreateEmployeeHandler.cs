using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Exceptions;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Core.Services.Commands;
using System.Net;

namespace RedarborTechnicalTest.Core.Services.EventHandlers
{
    public class CreateEmployeeHandler: IRequestHandler<CreateEmployeeCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        private readonly IEnumerable<IValidator<CreateEmployeeCommand>> _validators;

        public CreateEmployeeHandler(IMapper mapper
            , IRepository<EmployeeEntity> employeeRepository
            , IEnumerable<IValidator<CreateEmployeeCommand>> validators)
        { 
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _validators = validators;
        }
        public async Task<Unit> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeeEntity>(command.employeeDto);
            await _employeeRepository.Add(employee);
            return Unit.Value;
        }
    }
}
