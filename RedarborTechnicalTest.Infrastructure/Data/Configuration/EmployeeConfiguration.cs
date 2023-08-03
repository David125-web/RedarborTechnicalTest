using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedarborTechnicalTest.Core.Entities;

namespace RedarborTechnicalTest.Infrastructure.Data.Configuration
{
    public class EmployeeConfiguration
    {
        public EmployeeConfiguration(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("EMPLOYEE");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.CompanyId)
                .HasColumnName("COMPANYID");

            builder.Property(e => e.CreatedOn)
                .HasColumnName("CREATEDON");

            builder.Property(e => e.DeletedOn)
                .HasColumnName("DELETEON");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("EMAIL");

            builder.Property(e => e.Fax)
                .HasColumnName("FAX");

            builder.Property(e => e.Name)
                .HasColumnName("NAME");

            builder.Property(e => e.Lastlogin)
                .HasColumnName("LASTLOGIN");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("PASSWORD");

            builder.Property(e => e.PortalId)
                .IsRequired()
                .HasColumnName("PORTALID");

            builder.Property(e => e.RoleId)
                .IsRequired()
                .HasColumnName("ROLEID");

            builder.Property(e => e.StatusId)
                .IsRequired()
                .HasColumnName("STATUSID");

            builder.Property(e => e.Telephone)
                .HasColumnName("TELEPHONE");

            builder.Property(e => e.UpdatedOn)
                .HasColumnName("UPDATEDON");

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("USERNAME");
        }
    }
}
