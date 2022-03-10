using System;
using System.IO;
using System.Text;

namespace PainAssessment.Areas.Admin.Services
{
    public sealed class Log : ILog
    {
        private Log() { }

        private static readonly Lazy<Log> instance = new(() => new Log());

        public static Log GetInstance => instance.Value;
        public void LogMessage(string area, string type, string message)
        {
            string date = DateTime.Now.ToShortDateString();
            string fileName = string.Format("{0}.log", date.Replace("/", "_"));
            string logFileDirectory = string.Format(@"{0}\logs", AppDomain.CurrentDomain.BaseDirectory);
            string logFilePath = string.Format(@"{0}\logs\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (!Directory.Exists(logFileDirectory))
            {
                Directory.CreateDirectory(logFileDirectory);
            }
            StringBuilder sb = new();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            string output = string.Format("${0}: {1}  {2}  ", type, area, message);
            sb.AppendLine(output);
            using StreamWriter writer = new(logFilePath, true);
            writer.Write(sb.ToString());
            writer.Flush();
        }
    }
}
