using System;

namespace Framework.Logger.ACL
{
    public interface IFrameworkLoggerService
    {
        void Log(string title, string description, int type, int userId);
    }
}