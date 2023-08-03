using MediatR;
using RedarborTechnicalTest.Core.Dtos;

namespace RedarborTechnicalTest.Core.Services.Commands
{
    public record CreateEmployeeCommand(EmployeeDto employeeDto) : IRequest;
}
