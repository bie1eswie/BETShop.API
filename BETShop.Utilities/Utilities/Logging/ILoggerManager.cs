using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Infrastructure.Logging
{
		public interface ILoggerManager
		{
        void Information(string message);
        //void LogInfo(object results, string stackTrace);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
        void LogFatal(string message);
        void LogFatal(Exception exception);
    }
}
