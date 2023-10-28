using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using AutoRestarter.Tools;

namespace AutoRestarter.Functions;

internal class Settings
{
    private static readonly string settingsFilePath = "AutoRestarter_Settings.txt";

    // Reference parent window
    private readonly MainWindow m_WndRef;

    public Settings(MainWindow _wndRef)
    {
        m_WndRef = _wndRef;
    }

    public static void SaveSetting(int row, string name, bool? auto, string? path, string launchOptions)
    {
        var allSettings = ReadAllSettings();

        var newSettings = $"{row},{name},{auto},{path},{launchOptions}";
        Logs.Log($"Saved: {newSettings}");

        var rowUpdated = false;

        for (var i = 0; i < allSettings.Count; i++)
        {
            var existingSetting = allSettings[i];
            var parts = existingSetting.Split(',');
            if (parts.Length >= 5 && int.TryParse(parts[0], out var existingRow))
                if (existingRow == row)
                {
                    allSettings[i] = newSettings;
                    rowUpdated = true;
                }
        }

        if (!rowUpdated) allSettings.Add(newSettings);

        try
        {
            File.WriteAllLines(settingsFilePath, allSettings);
            Logs.Log("Settings saved successfully.");
        }
        catch (Exception ex)
        {
            Logs.Log($"Error: {ex.Message}");
        }
    }

    public static List<string> ReadAllSettings()
    {
        var settings = new List<string>();

        if (File.Exists(settingsFilePath))
            try
            {
                settings = File.ReadAllLines(settingsFilePath).ToList();
            }
            catch (Exception ex)
            {
                Logs.Log($"Error reading settings: {ex.Message}");
            }

        return settings;
    }

    public void LoadSettings()
    {
        if (File.Exists(settingsFilePath))
        {
            var loadedSettings = ReadAllSettings();
            Logs.Log("Applying the Settings");

            foreach (var setting in loadedSettings)
            {
                var settingsParts = setting.Split(',');

                if (settingsParts.Length >= 5 && int.TryParse(settingsParts[0], out var row))
                {
                    if (row == 1)
                    {
                        if (settingsParts[1] != "")
                        {
                            m_WndRef.SettingsExeName1.Text = settingsParts[1];

                            m_WndRef.SettingsFolderLocation1.Text = settingsParts[3];
                            m_WndRef.SettingsLaunchOptions1.Text = settingsParts[4];

                            m_WndRef.ExeName1.Text = settingsParts[1];
                            m_WndRef.CheckBox1.IsChecked = bool.Parse(settingsParts[2]);

                            m_WndRef.StatsColor1.Visibility = Visibility.Visible;
                            m_WndRef.ExeName1.Visibility = Visibility.Visible;
                            m_WndRef.CheckBox1.Visibility = Visibility.Visible;
                            m_WndRef.StartStop1.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            m_WndRef.StatsColor1.Visibility = Visibility.Hidden;
                            m_WndRef.ExeName1.Visibility = Visibility.Hidden;
                            m_WndRef.CheckBox1.Visibility = Visibility.Hidden;
                            m_WndRef.StartStop1.Visibility = Visibility.Hidden;
                        }
                    }

                    if (row == 2)
                    {
                        if (settingsParts[1] != "")
                        {
                            m_WndRef.SettingsExeName2.Text = settingsParts[1];

                            m_WndRef.SettingsFolderLocation2.Text = settingsParts[3];
                            m_WndRef.SettingsLaunchOptions2.Text = settingsParts[4];

                            m_WndRef.ExeName2.Text = settingsParts[1];
                            m_WndRef.CheckBox2.IsChecked = bool.Parse(settingsParts[2]);

                            m_WndRef.StatsColor2.Visibility = Visibility.Visible;
                            m_WndRef.ExeName2.Visibility = Visibility.Visible;
                            m_WndRef.CheckBox2.Visibility = Visibility.Visible;
                            m_WndRef.StartStop2.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            m_WndRef.StatsColor2.Visibility = Visibility.Hidden;
                            m_WndRef.ExeName2.Visibility = Visibility.Hidden;
                            m_WndRef.CheckBox2.Visibility = Visibility.Hidden;
                            m_WndRef.StartStop2.Visibility = Visibility.Hidden;
                        }
                    }

                    if (row == 3)
                    {
                        if (settingsParts[1] != "")
                        {
                            m_WndRef.SettingsExeName3.Text = settingsParts[1];
                            m_WndRef.SettingsFolderLocation3.Text = settingsParts[3];
                            m_WndRef.SettingsLaunchOptions3.Text = settingsParts[4];

                            m_WndRef.ExeName3.Text = settingsParts[1];
                            m_WndRef.CheckBox3.IsChecked = bool.Parse(settingsParts[2]);

                            m_WndRef.StatsColor3.Visibility = Visibility.Visible;
                            m_WndRef.ExeName3.Visibility = Visibility.Visible;
                            m_WndRef.CheckBox3.Visibility = Visibility.Visible;
                            m_WndRef.StartStop3.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            m_WndRef.StatsColor3.Visibility = Visibility.Hidden;
                            m_WndRef.ExeName3.Visibility = Visibility.Hidden;
                            m_WndRef.CheckBox3.Visibility = Visibility.Hidden;
                            m_WndRef.StartStop3.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }
        else
        {
            m_WndRef.StatsColor1.Visibility = Visibility.Hidden;
            m_WndRef.ExeName1.Visibility = Visibility.Hidden;
            m_WndRef.CheckBox1.Visibility = Visibility.Hidden;
            m_WndRef.StartStop1.Visibility = Visibility.Hidden;

            m_WndRef.StatsColor2.Visibility = Visibility.Hidden;
            m_WndRef.ExeName2.Visibility = Visibility.Hidden;
            m_WndRef.CheckBox2.Visibility = Visibility.Hidden;
            m_WndRef.StartStop2.Visibility = Visibility.Hidden;

            m_WndRef.StatsColor3.Visibility = Visibility.Hidden;
            m_WndRef.ExeName3.Visibility = Visibility.Hidden;
            m_WndRef.CheckBox3.Visibility = Visibility.Hidden;
            m_WndRef.StartStop3.Visibility = Visibility.Hidden;
        }
    }
}