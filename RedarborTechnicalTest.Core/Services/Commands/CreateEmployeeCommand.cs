using MediatR;
using RedarborTechnicalTest.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace RedarborTechnicalTest.Core.Services.Commands
{
    public record CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        [Required]
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        [Required]
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public DateTime Lastlogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int PortalId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool StatusId { get; set; }
        public string Telephone { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
