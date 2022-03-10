namespace PainAssessment.Areas.Admin.Models
{
    public interface IPractitioner
    {
        string[] SelectedPainEducation { get; set; }

        public void AddPatientRelation(Patient patient);
    }
}
