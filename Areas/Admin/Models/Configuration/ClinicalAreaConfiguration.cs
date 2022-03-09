using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class ClinicalAreaConfiguration : IEntityTypeConfiguration<ClinicalArea>
    {
        public void Configure(EntityTypeBuilder<ClinicalArea> builder)
        {
            builder.ToTable("ClinicalArea");
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
