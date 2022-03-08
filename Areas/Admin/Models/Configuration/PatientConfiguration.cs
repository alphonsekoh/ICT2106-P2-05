using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
