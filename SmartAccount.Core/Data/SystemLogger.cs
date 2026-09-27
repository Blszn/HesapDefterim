using System;
using System.IO;

namespace SmartAccount.Core.Data
{
    public static class SystemLogger
    {
        private static string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "system_logs.txt");
        public static string CurrentUsername { get; set; } = "Sistem";

        public static void Log(string action)
        {
            try
            {
                string logEntry = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] Kullanıcı: " + CurrentUsername + " | İşlem: " + action + Environment.NewLine;
                File.AppendAllText(LogFilePath, logEntry);
            }
            catch { }
        }

        public static void ExportLogs(string destinationPath)
        {
            if (File.Exists(LogFilePath))
            {
                File.Copy(LogFilePath, destinationPath, true);
            }
            else
            {
                File.WriteAllText(destinationPath, "Henüz sistem logu bulunmamaktadır.");
            }
        }
    }
}
