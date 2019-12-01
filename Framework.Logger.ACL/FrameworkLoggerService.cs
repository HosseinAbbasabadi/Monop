using Logging.Application;

namespace Framework.Logger.ACL
{
    public class FrameworkLoggerService : IFrameworkLoggerService
    {
        private readonly ILogApplication _logApplication;

        public FrameworkLoggerService(ILogApplication logApplication)
        {
            _logApplication = logApplication;
        }

        public void Log(string title, string description, int type, int userId)
        {
            var logInfo = new LogInfo
            {
                Title = title,
                Description = description,
                UserId = userId,
                Type = type
            };
            _logApplication.AddLog(logInfo);
        }
    }
}