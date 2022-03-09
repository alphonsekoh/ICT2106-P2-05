using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PracticeTypeConfiguration : IEntityTypeConfiguration<PracticeType>
    {
        public void Configure(EntityTypeBuilder<PracticeType> builder)
        {
            builder.ToTable("PracticeType");
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
