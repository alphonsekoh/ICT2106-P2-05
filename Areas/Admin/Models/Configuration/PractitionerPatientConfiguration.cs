using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PractitionerPatientConfiguration : IEntityTypeConfiguration<PractitionerPatient>
    {
        public void Configure(EntityTypeBuilder<PractitionerPatient> builder)
        {
            builder
                .ToTable("PractitionerPatient");

        }
    }
}
