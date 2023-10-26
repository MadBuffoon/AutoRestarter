using System;
using System.IO;

namespace AutoRestarter.Tools;

internal class Logs
{
    // Reference parent window
    private static MainWindow m_WndRef;
    private static readonly string logFilePath = "Logs/AutoRestarter.log";

    public Logs(MainWindow _wndRef)
    {
        m_WndRef = _wndRef;
    }

    public static void Log(string message)
    {
        // Log to patcher_log.txt file
        File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        LogUpdate();
        m_WndRef.LogScrollViewer.ScrollToBottom();
    }

    private static void LogUpdate()
    {
        if (File.Exists(logFilePath))
            try
            {
                var logData = File.ReadAllText(logFilePath);
                m_WndRef.LogTextBox.Text = logData;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur when reading the file
                // You can log the exception or display an error message
            }
    }


    public static void ClearLog()
    {
        if (!Directory.Exists("Logs"))
            Directory.CreateDirectory("Logs");
        if (File.Exists(logFilePath))
            File.Delete(logFilePath);
    }
}