using FluentValidation;
using RedarborTechnicalTest.Core.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.Core.Validators.Commands
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.CompanyId)
                .NotNull()
                .WithMessage("El campo CompanyId no puede ser nulo");
            RuleFor(x => x.Email)
                 .NotNull()
                 .WithMessage("El campo Email, no puede ser nulo");
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("El campo Password no puede ser nulo");
            RuleFor(x => x.PortalId)
                .NotNull()
                .WithMessage("El campo PortalId no puede ser nulo");
            RuleFor(x => x.RoleId)
                .NotNull()
                .WithMessage("El campo RoleId no puede ser nulo");
        }
    }
}
