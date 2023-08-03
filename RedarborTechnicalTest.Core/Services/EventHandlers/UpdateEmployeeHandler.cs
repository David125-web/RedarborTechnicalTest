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
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Unit>

    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        private readonly IEnumerable<IValidator<UpdateEmployeeCommand>> _validators;

        public UpdateEmployeeHandler(IMapper mapper
            , IRepository<EmployeeEntity> employeeRepository
            , IEnumerable<IValidator<UpdateEmployeeCommand>> validators)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _validators = validators;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<UpdateEmployeeCommand>(command);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
            {
                List<string> errors = new List<string>();
                foreach (ValidationFailure failule in failures)
                {
                    errors.Add(failule.ErrorMessage);
                }
                throw new BusinessException { CodeResponse = HttpStatusCode.BadRequest, Errors = errors, ErrorMessage = "Error al actualizar un empleado." };
            }
            var employee = await _employeeRepository.GetById(command.id);
            if (employee == null) throw new BusinessException() { CodeResponse = HttpStatusCode.NotFound, ErrorMessage = $"Empleado con id {command.id} no existe." };
            employee = _mapper.Map<EmployeeEntity>(command.employeeDto);
            employee.Id = command.id;
            await _employeeRepository.Update(employee);
            return Unit.Value;
        }
    }
}
