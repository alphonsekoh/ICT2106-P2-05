namespace PainAssessment.Areas.Admin.Services
{
    public interface ILogService
    {
        void LogMessage(string area, string type, string message);
    }
}
