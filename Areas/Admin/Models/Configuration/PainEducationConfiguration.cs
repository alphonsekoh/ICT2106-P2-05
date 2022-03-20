using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PainEducationConfiguration : IEntityTypeConfiguration<PainEducation>
    {
        public void Configure(EntityTypeBuilder<PainEducation> builder)
        {
            builder.ToTable("PainEducation");
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
