using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PainAssessment.Areas.Admin.Models.Configuration
{
    public class PractitionerConfiguration : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder.ToTable("Practitioner");
            builder.HasMany(p => p.Patients)
                .WithMany(p => p.Practitioners)
                .UsingEntity<PractitionerPatient>(
                j => j.HasOne(pp => pp.Patient)
                      .WithMany(p => p.PractitionerPatients)
                      .HasForeignKey(pp => pp.PatientID),
                j => j.HasOne(pp => pp.Practitioner)
                      .WithMany(p => p.PractitionerPatients)
                      .HasForeignKey(pp => pp.PractitionerID),
                j =>
                {
                    j.HasKey(p => new { p.PractitionerID, p.PatientID });
                });
            builder.HasOne(p => p.ClinicalArea)
                    .WithMany(ca => ca.Practitioners)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.PracticeType)
                .WithMany(ca => ca.Practitioners)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
