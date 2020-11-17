using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Green_Engine.Green
{
    public static class Logger
    {
        /// <summary>
        /// Global Log timestamp.
        /// </summary>
        private static readonly string logTimestampFormat = "MM-dd-yy::HH:mm:ss";

        private static BlockingCollection<LogObject> blockingQueue = new BlockingCollection<LogObject>();

        private static List<string> RegisteredLogs;

        internal static void Init()
        {
            Thread thread = new Thread(()
                =>
            {
                while (true) WriteLog(blockingQueue.Take());
            });
            thread.IsBackground = true;
            thread.Start();
        }

        //boilerplate functions.
        public static void Info(string message, params object[] args)
        {
            Log(message, Severity.INFO, args);
        }

        public static void Warn(string message, params object[] args)
        {
            Log(message, Severity.WARN, args);
        }        
        public static void Error(string message, params object[] args)
        {
            Log(message, Severity.ERROR, args);
        }        
        
        public static void Critical(string message, params object[] args)
        {
            Log(message, Severity.CRITICAL, args);
        }

        public static void Log(string message, Severity logSeverity, params object[] args)
        {
            blockingQueue.Add(new LogObject()
            {
                severity = logSeverity,
                Message = string.Format(message, args),
                Timestamp = DateTime.Now.ToString(logTimestampFormat),
                Sender = "API"

            }); 
        }

        public static void Log(int LoggerID, string message, Severity logSeverity, params object[] args)
        {
            if (LoggerID >= RegisteredLogs.Count)
                throw new ArgumentException("LoggerID must be attached to a registered logger");

            blockingQueue.Add(new LogObject()
            {
                severity = logSeverity,
                Message = string.Format(message, args),
                Timestamp = DateTime.Now.ToString(logTimestampFormat),
                Sender = RegisteredLogs[LoggerID]

            });
        }

        public static int RegisterLogger(string LogName)
        {
            if (LogName == "" || RegisteredLogs.Contains(LogName))
                throw new ArgumentException("Logger name cannot be a duplicate of another logger, and cannot be an empty string.");
            RegisteredLogs.Add(LogName);
            return RegisteredLogs.Count - 1;
        }


        internal static void Info_int(string message, params object[] args)
        {
            Log_int(message, Severity.INFO, args);
        }

        internal static void Warn_int(string message, params object[] args)
        {
            Log_int(message, Severity.WARN, args);
        }
        internal static void Error_int(string message, params object[] args)
        {
            Log_int(message, Severity.ERROR, args);
        }

        internal static void Critical_int(string message, params object[] args)
        {
            Log_int(message, Severity.CRITICAL, args);
        }

        internal static void Log_int(string message, Severity logSeverity, params object[] args)
        {
            blockingQueue.Add(new LogObject()
            {
                severity = logSeverity,
                Message = string.Format(message, args),
                Timestamp = DateTime.Now.ToString(logTimestampFormat),
                Sender = "ENGINE"

            });
        }



        static void WriteLog(LogObject logToWrite)
        {
            Console.Write($"[{logToWrite.Sender}:{logToWrite.Timestamp}]["); //eg: [ENGINE:2:40:33][

            switch (logToWrite.severity)
            {
                case Severity.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Severity.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Severity.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Severity.CRITICAL: //roll that critical.
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.Write($"{Enum.GetName(typeof(Severity), logToWrite.severity)}");
            Console.ResetColor();
            Console.WriteLine($"]:{logToWrite.Message}");
        }

        public enum Severity
        {
            INFO,
            WARN,
            ERROR,
            CRITICAL
        }

    }

    internal struct LogObject
    {
        public string Timestamp;
        public string Message;
        public string Sender;
        public Logger.Severity severity;

    }
}
