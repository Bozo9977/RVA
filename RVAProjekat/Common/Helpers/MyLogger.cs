using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class MyLogger
    {
        private LogHelper logHelper;
        private static MyLogger instance;
        private static object x = new object();

        private MyLogger() { }

        public static MyLogger Instance()
        {
            lock (x)
            {
                if (instance == null)
                    instance = new MyLogger();
                return instance;
            }
        }

        public void Log(string message, string user, string level)
        {
            logHelper = new LogHelper(user);
            switch (level)
            {
                case "INFO": logHelper.Logger.Info($"{user} {message}"); break;
                case "FATAL": logHelper.Logger.Info($"{user} {message}"); break;
                case "ERROR": logHelper.Logger.Info($"{user} {message}"); break;
            }
            logHelper = null;
        }

    }
}
