using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class ClinicalAreaConfiguration : IEntityTypeConfiguration<ClinicalArea>
    {
        public void Configure(EntityTypeBuilder<ClinicalArea> builder)
        {
            builder.ToTable("ClinicalArea");
        }
    }
}
