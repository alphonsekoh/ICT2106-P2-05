using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PracticeTypeConfiguration  : IEntityTypeConfiguration<PracticeType>
    {
        public void Configure(EntityTypeBuilder<PracticeType> builder)
    {
        builder.ToTable("PracticeType");
        builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    }
}
