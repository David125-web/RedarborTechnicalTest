using MediatR;
using RedarborTechnicalTest.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.Core.Services.Commands
{
    public record UpdateEmployeeCommand(int id, EmployeeDto employeeDto) : IRequest;
}
