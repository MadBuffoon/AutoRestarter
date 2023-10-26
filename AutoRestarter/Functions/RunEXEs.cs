using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using AutoRestarter.Tools;

namespace AutoRestarter.Functions;

public class RunEXEs
{
    private readonly Dictionary<string, Task> autoRestartTasks = new();

    private readonly string currentLoction = MainWindow.CurrentInstalLoction();

    private readonly List<string> loadedSettings = Settings.ReadAllSettings();

    // Reference parent window
    private readonly MainWindow m_WndRef;
    private bool stopStatusCheck; // This variable will control when to stop the status checks.

    public RunEXEs(MainWindow _wndRef)
    {
        m_WndRef = _wndRef;
    }

    public void StartEXEs(string start, bool AutoCheck)
    {
        if (!AutoCheck) Logs.Log($"Starting the {start}");
        foreach (var setting in loadedSettings)
        {
            var settingsParts = setting.Split(',');

            if (settingsParts.Length >= 5 && int.TryParse(settingsParts[0], out var row))
            {
                if (row == 1 && (start == "EXE1" || start == "Auto" || start == "Stop1"))
                {
                    var ExeName = settingsParts[1];
                    var FolderLocation = currentLoction + @"\" + settingsParts[3] + @"\";
                    var LaunchOptions = settingsParts[4];
                    var Auto = bool.Parse(settingsParts[2]);

                    if (start != "Stop1")
                    {
                        if (Auto)
                        {
                            // Check if the process is already running
                            var existingProcess = IsExeRunning(ExeName);
                            if (!existingProcess)
                                // Start the process and create an auto-restart task
                                StartExeWithAutoRestart(ExeName, FolderLocation, LaunchOptions);
                            else if (!AutoCheck)
                                Logs.Log($"{ExeName} is already running.");
                        }
                        else if (start == "EXE1")
                        {
                            // Handle the case when Auto is false
                            Logs.Log($"{ExeName} won't be automatically restarted.");
                            StartEXE(ExeName, FolderLocation, LaunchOptions);
                        }
                    }
                    else
                    {
                        StopEXE(ExeName);
                    }
                }

                if (row == 2 && (start == "EXE2" || start == "Auto" || start == "Stop2"))
                {
                    var ExeName = settingsParts[1];
                    var FolderLocation = currentLoction + @"\" + settingsParts[3] + @"\";
                    var LaunchOptions = settingsParts[4];
                    var Auto = bool.Parse(settingsParts[2]);

                    if (start != "Stop2")
                    {
                        if (Auto)
                        {
                            // Check if the process is already running
                            var existingProcess = IsExeRunning(ExeName);
                            if (!existingProcess)
                                // Start the process and create an auto-restart task
                                StartExeWithAutoRestart(ExeName, FolderLocation, LaunchOptions);
                            else if (!AutoCheck)
                                Logs.Log($"{ExeName} is already running.")
                                    ;
                        }
                        else if (start == "EXE2")
                        {
                            // Handle the case when Auto is false
                            Logs.Log($"{ExeName} won't be automatically restarted.");
                            StartEXE(ExeName, FolderLocation, LaunchOptions);
                        }
                    }
                    else
                    {
                        StopEXE(ExeName);
                    }
                }

                if (row == 3 && (start == "EXE3" || start == "Auto" || start == "Stop3"))
                {
                    var ExeName = settingsParts[1];
                    var FolderLocation = currentLoction + @"\" + settingsParts[3] + @"\";
                    var LaunchOptions = settingsParts[4];
                    var Auto = bool.Parse(settingsParts[2]);

                    if (start != "Stop3")
                    {
                        if (Auto)
                        {
                            // Check if the process is already running
                            var existingProcess = IsExeRunning(ExeName);
                            if (!existingProcess)
                                // Start the process and create an auto-restart task
                                StartExeWithAutoRestart(ExeName, FolderLocation, LaunchOptions);
                            else if (!AutoCheck)
                                Logs.Log($"{ExeName} is already running.")
                                    ;
                        }
                        else if (start == "EXE3")
                        {
                            // Handle the case when Auto is false
                            Logs.Log($"{ExeName} won't be automatically restarted.");
                            StartEXE(ExeName, FolderLocation, LaunchOptions);
                        }
                    }
                    else
                    {
                        StopEXE(ExeName);
                    }
                }
            }
        }
    }

    private Process GetRunningProcess(string processName)
    {
        var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName));
        return processes.Length > 0 ? processes[0] : null;
    }

    public async Task StartAuto()
    {
        stopStatusCheck = false;

        while (!stopStatusCheck)
        {
            StartEXEs("Auto", true);
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    private void StartExeWithAutoRestart(string exeName, string folderLocation, string launchOptions)
    {
        if (File.Exists(Path.Combine(folderLocation, exeName))) // Check if the executable file exists
        {
            Logs.Log($"Starting {exeName} with auto-restart");

            if (!AutoShouldContinue(exeName))
                return;

            // Check if there is an existing process with the same name
            if (!IsExeRunning(exeName))
                // Logs.Log($"Starting {exeName}");
                // Logs.Log($"Working Directory: {folderLocation}");
                // Logs.Log($"Command Line Arguments: {launchOptions}");
                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(folderLocation, exeName),
                    WorkingDirectory = folderLocation,
                    Arguments = launchOptions,
                    UseShellExecute = true
                });
            else
                Logs.Log($"{exeName} is already running.");
            // You may add a delay between restart attempts, e.g., Task.Delay(TimeSpan.FromSeconds(30)).Wait();
        }
        else
        {
            Logs.Log($"{exeName} does not exist. Cannot start.");
        }
    }


    private bool AutoShouldContinue(string exeName)
    {
        var autoValue =
            bool.Parse(GetSettingsForEXE(exeName,
                2)); // 2 corresponds to the "True" or "False" part in the example settings
        Logs.Log($"AutoShouldContinue {autoValue}");
        return autoValue;
    }


    // Helper method to get settings for a specific EXE
    private string GetSettingsForEXE(string exeName, int fieldIndex)
    {
        foreach (var setting in loadedSettings)
        {
            var settingsParts = setting.Split(',');
            if (settingsParts.Length >= 2)
            {
                var currentEXEName = settingsParts[1].Trim();
                if (currentEXEName.Equals(exeName, StringComparison.OrdinalIgnoreCase) && fieldIndex >= 0 &&
                    fieldIndex < settingsParts.Length)
                {
                    // Logs.Log($"Matching setting: {setting}");
                    // Logs.Log($"currentEXEName: {currentEXEName}.exe");
                    // Logs.Log($"fieldIndex: {fieldIndex}");
                    // Logs.Log($"Field value: {settingsParts[fieldIndex]}");
                    if (fieldIndex != 3)
                        return settingsParts[fieldIndex].Trim();
                    return currentLoction + settingsParts[fieldIndex].Trim();
                }
            }
        }


        return
            null; // Return null if settings for the specified EXE are not found or if the field index is out of range
    }

    private void StartEXE(string exeName, string folderLocation, string launchOptions)
    {
        if (File.Exists(folderLocation + exeName)) // Check if the executable file exists
        {
            Logs.Log($"{exeName} is starting.");
            var autoValue = bool.Parse(GetSettingsForEXE(exeName, 2));
            if (!autoValue)
            {
                var existingProcess = IsExeRunning(exeName);
                if (!existingProcess)
                    try
                    {
                        // Logs.Log($"Starting {exeName}.exe");
                        // Logs.Log($"Working Directory: {folderLocation}");
                        // Logs.Log($"Command Line Arguments: {launchOptions}");
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = exeName,
                            WorkingDirectory = folderLocation,
                            Arguments = launchOptions,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        Logs.Log($"Exception3: {ex}");
                    }
                else
                    Logs.Log($"{exeName} is already running.");
            }
            else
            {
                StartExeWithAutoRestart(exeName, folderLocation, launchOptions);
            }
        }
        else
        {
            Logs.Log($"{exeName} does not exist. Cannot start.");
            Logs.Log($"Folder Location: {folderLocation}");
        }
    }


    public void StopEXE(string exeName)
    {
        var process = GetRunningProcess(exeName);
        if (process != null)
        {
            if (process.CloseMainWindow())
            {
                // The main window of the process responded to the request to close.
                Console.WriteLine($"Requested process {process.ProcessName} (ID: {process.Id}) to close.");
            }
            else
            {
                // If CloseMainWindow returns false, it means the process didn't respond to the request.
                // In this case, you can resort to killing the process.
                process.Kill();
                Console.WriteLine($"Terminated process {process.ProcessName} (ID: {process.Id}).");
            }
        }
        else
        {
            Logs.Log($"{exeName} is not running.");
        }

        // Stop the associated auto-restart task if it exists
        if (autoRestartTasks.ContainsKey(exeName))
        {
            autoRestartTasks[exeName].Wait(); // Wait for the task to complete
            autoRestartTasks.Remove(exeName); // Remove the task
        }
    }

    private void StatusColor(string exeName, bool running)
    {
        var row = GetSettingsForEXE(exeName, 0);
        var rowNumber = int.Parse(row);
        var statsColors = new[] { m_WndRef.StatsColor1.Fill, m_WndRef.StatsColor2.Fill, m_WndRef.StatsColor3.Fill };
        if (rowNumber >= 0 && rowNumber <= statsColors.Length)
        {
            //Logs.Log($"Row Number {rowNumber}");
            var colorIndex = rowNumber - 1; // Subtract 1 to account for 0-based indexing
            if (running)
                statsColors[colorIndex] = new SolidColorBrush(Colors.Green);
            else
                statsColors[colorIndex] = new SolidColorBrush(Colors.Red);

            // Update the UI elements with the new SolidColorBrush
            if (rowNumber == 1)
                //Logs.Log($"Stats 1 {rowNumber}");
                m_WndRef.StatsColor1.Fill = statsColors[colorIndex];
            else if (rowNumber == 2)
                //Logs.Log($"Stats 2 {rowNumber}");
                m_WndRef.StatsColor2.Fill = statsColors[colorIndex];
            else if (rowNumber == 3)
                //Logs.Log($"Stats 3 {rowNumber}");
                m_WndRef.StatsColor3.Fill = statsColors[colorIndex];
        }
    }

    public async Task StartStatusCheck()
    {
        stopStatusCheck = false;

        while (!stopStatusCheck)
        {
            await CheckStatusForAllExesAsync();
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    public void StopStatusCheck()
    {
        stopStatusCheck = true;
    }

    private Task CheckStatusForAllExesAsync()
    {
        //Logs.Log($"Doing Check for Stats");
        foreach (var setting in loadedSettings)
        {
            var settingsParts = setting.Split(',');

            if (settingsParts.Length >= 5 && int.TryParse(settingsParts[0], out var row))
            {
                var exeName = settingsParts[1];
                var folderLocation = currentLoction + @"\" + settingsParts[3] + @"\";

                if (File.Exists(Path.Combine(folderLocation, exeName))) // Check if the executable file exists
                {
                    var isRunning = IsExeRunning(exeName);
                    if (isRunning)
                        //Logs.Log($"{exeName} is running");
                        StatusColor(exeName, true);
                    else
                        // Logs.Log($"{exeName} is not running");
                        StatusColor(exeName, false);
                }
            }
        }

        return Task.CompletedTask;
    }

    private bool IsExeRunning(string exeName)
    {
        var processes = GetRunningProcess(exeName);
        if (processes == null)
            return false;
        return true;
    }
}