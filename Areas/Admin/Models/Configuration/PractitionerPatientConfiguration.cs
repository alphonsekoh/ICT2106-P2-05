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
            builder.HasKey(t => new { t.PractitionerID, t.PatientID });

            builder.HasOne(pp => pp.Practitioner)
                   .WithMany(pp => pp.PractitionerPatients)
                   .HasForeignKey(pp => pp.PractitionerID);

            builder.HasOne(pp => pp.Patient)
                   .WithMany(pp => pp.PractitionerPatients)
                   .HasForeignKey(pp => pp.PatientID);
        }
    }
}
