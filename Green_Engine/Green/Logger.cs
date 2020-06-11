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
        private static BlockingCollection<LogObject> blockingQueue = new BlockingCollection<LogObject>();

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
                Timestamp = DateTime.Now.ToString("HH:mm:ss"),
                Sender = "API"

            }); 
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
                Timestamp = DateTime.Now.ToString("MM-DD-YY::HH:mm:ss"),
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
