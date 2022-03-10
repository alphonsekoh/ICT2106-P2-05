namespace PainAssessment.Areas.Admin.Services
{
    public interface ILog
    {
        void LogMessage(string area, string type, string message);

    }
}
