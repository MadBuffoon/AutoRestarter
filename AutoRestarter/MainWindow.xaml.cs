using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoRestarter.Functions;
using AutoRestarter.Tools;

namespace AutoRestarter;

public partial class MainWindow : Window
{
    private readonly RunEXEs m_EXEs;
    private readonly Logs m_Logs;

    private readonly Settings m_Settings;


    public MainWindow()
    {
        m_Settings = new Settings(this);
        m_EXEs = new RunEXEs(this);
        m_Logs = new Logs(this);
        InitializeComponent();
        Logs.ClearLog();
        Logs.Log("Started UP");
        m_Settings.LoadSettings();
        m_EXEs.StartEXEs("Auto", false);
#pragma warning disable CS4014
        m_EXEs.StartStatusCheck();
        m_EXEs.StartAuto();
#pragma warning restore CS4014
        var processName = "AutoRestarter";
        var currentProcessId = Process.GetCurrentProcess().Id;

        var processes = Process.GetProcessesByName(processName);

        if (processes.Length > 0)
            foreach (var process in processes)
                if (process.Id != currentProcessId)
                    process.Kill();
    }

    public static string? CurrentInstalLoction()
    {
        var exePath = Assembly.GetEntryAssembly().Location;
        var exeDirectory = Path.GetDirectoryName(exePath);
        return exeDirectory;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        // Save the settings using the Settings class
        Settings.SaveSetting(1, SettingsExeName1.Text, CheckBox1.IsChecked, SettingsFolderLocation1.Text,
            SettingsLaunchOptions1.Text);
        Settings.SaveSetting(2, SettingsExeName2.Text, CheckBox2.IsChecked, SettingsFolderLocation2.Text,
            SettingsLaunchOptions2.Text);
        Settings.SaveSetting(3, SettingsExeName3.Text, CheckBox3.IsChecked, SettingsFolderLocation3.Text,
            SettingsLaunchOptions3.Text);

        // Optionally, you can also load the settings to update the UI
        m_Settings.LoadSettings();
        Task.Delay(TimeSpan.FromSeconds(1));
        m_EXEs.StartEXEs("Auto", false);
    }

    public void LogTabItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (LogTabItem.IsSelected)
            // Scroll to the bottom of the ScrollViewer when the "Log" tab is selected.
            LogScrollViewer.ScrollToBottom();
    }

    private void Start1_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("EXE1", false);
    }

    private void Stop1_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("Stop1", false);
    }

    private void Start2_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("EXE2", false);
    }

    private void Stop2_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("Stop2", false);
    }

    private void Start3_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("EXE3", false);
    }

    private void Stop3_Click(object sender, RoutedEventArgs e)
    {
        m_EXEs.StartEXEs("Stop3", false);
    }
}