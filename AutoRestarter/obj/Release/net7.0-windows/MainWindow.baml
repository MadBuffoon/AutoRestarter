   M S B A M L   `   `   `  ����   AutoRestarter    AutoRestarter.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  AutoRestarter��$	��450��$	��800��.��� .+��� .@��� $��Status��.��� -   $��
StatusGrid��$��0,0,0,30q� � RowDefinitions �� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30�� � ColumnDefinitions �� $��50 ��� $
��Auto �$	��300���� $��50 ��� $	��100 ��� $��50 �.+��� $��0��$��Status��$��0��$	��5,0q�$��Center=�$��Center=��� $��0��$
��Name��$��1��$	��5,0q�$��Center=�$��Center=��� $��0��$
��Auto��$��2��$	��5,0q�$��Center=�$��Center=��� $��0��$��
Start/Stop��$��3��$	��5,0q�$��Center=�$��Center=��� -    ��Name$ StatsColor1��$��1��$y�Visible=�
���  ��$��20��$��20��$��0��$	��5,5q�$��Center=�$��Center=��� -    ��Name$ ExeName1��$��1��$y�Visible=�$��A name��$��1��$	��5,5q�$��Center=�$��Center=��� -    ��Name$ 	CheckBox1��$��1��$y�Visible=�$��2��$	��5,5q�$��Center=�$��Center=�� -    �Name$ 
StartStop1��$��1��$��3��$	��5,5q�$y�Visible=�.+��� -    ��Name$ Start1��$��Start��$��0,0,52,0q��� -   $ Stop1��$
��Stop��$��52,0,0,0q��� -   $ StatsColor2��$��2��$y�Visible=�
���  ��$��20��$��20��$��0��$	��5,5q�$��Center=�$��Center=��� -	   $ ExeName2��$��2��$y�Visible=�$��A name��$��1��$	��5,5q�$��Center=�$��Center=��� -
   $ 	CheckBox2��$��2��$y�Visible=�$��2��$	��5,5q�$��Center=�$��Center=�� -   $ 
StartStop2��$��2��$��3��$	��5,5q�$y�Visible=�.+��� -   $ Start2��$��Start��$��0,0,52,0q��� -   $ Stop2��$
��Stop��$��52,0,0,0q��� -   $ StatsColor3��$��3��$y�Visible=�
���  ��$��20��$��20��$��0��$	��5,5q�$��Center=�$��Center=��� -   $ ExeName3��$��3��$y�Visible=�$��A name��$��1��$	��5,5q�$��Center=�$��Center=��� -   $ 	CheckBox3��$��3��$y�Visible=�$��2��$	��5,5q�$��Center=�$��Center=�� -   $ 
StartStop3��$��3��$��3��$	��5,5q�$y�Visible=�.+��� -   $ Start3��$��Start��$��0,0,52,0q��� -   $ Stop3��$
��Stop��$��52,0,0,0q��� -   $ StatsColor4��$��4��$y�Visible=�
���  ��$��20��$��20��$��0��$	��5,5q�$��Center=�$��Center=��� -   $ ExeName4��$��4��$y�Visible=�$��A name��$��1��$	��5,5q�$��Center=�$��Center=��� -   $ 	CheckBox4��$��4��$y�Visible=�$��2��$	��5,5q�$��Center=�$��Center=�� -   $ 
StartStop4��$��4��$��3��$	��5,5q�$y�Visible=�.+��� -   $ Start4��$��Start��$��0,0,52,0q��� -   $ Stop4��$
��Stop��$��52,0,0,0q��� -   $ StatsColor5��$��5��$y�Visible=�
���  ��$��20��$��20��$��0��$	��5,5q�$��Center=�$��Center=��� -   $ ExeName5��$��5��$y�Visible=�$��A name��$��1��$	��5,5q�$��Center=�$��Center=��� -   $ 	CheckBox5��$��5��$y�Visible=�$��2��$	��5,5q�$��Center=�$��Center=�� -   $ 
StartStop5��$��5��$��3��$	��5,5q�$y�Visible=�.+��� -   $ Start5��$��Start��$��0,0,52,0q��� -   $ Stop5��$
��Stop��$��52,0,0,0q��� $��Settings��.��� -    $��SettingsGrid��$��0,0,0,30q� �� $
��Auto �$��20���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30���� $
��Auto �$��30����  �� $
��Auto �$	��500���� $
��Auto �$	��500���� $��70 ��� $
��Auto �$	��500���� $��50 ��� .+��� $��EXE Name��$��0��$	��5,0q�$��Center=�$��Center=��� $��Folder Location��$��1��$	��5,0q�$��Center=�$��Center=��� $��Launch Options��$��3��$	��5,0q�$��Center=�$��Center=��� -!    ��Name$ SettingsExeName1��$��1��$�� ��$��0��$	��5,1q��� -"   $ SettingsFolderLocation1��$��1��$�� ��$��1��$	��5,1q��� -#   $��1��$��Browse��$��2��$	��5,1q��� -$   $ SettingsLaunchOptions1��$��1��$�� ��$��3��$	��5,1q��� -%   $ SettingsExeName2��$��2��$�� ��$��0��$	��5,1q��� -&   $ SettingsFolderLocation2��$��2��$�� ��$��1��$	��5,1q��� -'   $��2��$��Browse��$��2��$	��5,1q��� -(   $ SettingsLaunchOptions2��$��2��$�� ��$��3��$	��5,1q��� -)   $ SettingsExeName3��$��3��$�� ��$��0��$	��5,1q��� -*   $ SettingsFolderLocation3��$��3��$�� ��$��1��$	��5,1q��� -+   $��3��$��Browse��$��2��$	��5,1q��� -,   $ SettingsLaunchOptions3��$��3��$�� ��$��3��$	��5,1q��� --   $ SettingsExeName4��$��4��$�� ��$��0��$	��5,1q��� -.   $ SettingsFolderLocation4��$��4��$�� ��$��1��$	��5,1q��� -/   $��4��$��Browse��$��2��$	��5,1q��� -0   $ SettingsLaunchOptions4��$��4��$�� ��$��3��$	��5,1q��� -1   $ SettingsExeName5��$��5��$�� ��$��0��$	��5,1q��� -2   $ SettingsFolderLocation5��$��5��$�� ��$��1��$	��5,1q��� -3   $��5��$��Browse��$��2��$	��5,1q��� -4   $ SettingsLaunchOptions5��$��5��$�� ��$��3��$	��5,1q��� -5   	 ��Name$	 
LogTabItem��$	��Log��.��� -6   $	��Log��$��0,0,0,30q�.+��� -7   
 ��Name$
 LogScrollViewer��$
��Auto=�.���� -8   $��
LogTextBox��$
��Wrap=� �� Padding$ 5q�$��Consolas)��� -9   $
��Save��$��Right=�$��Bottom=�$��50��$��20��$��0,0,10,5q��� -:   $ VersionText��$�� ��$
��Left=�$��Bottom=�$	��100��$��20��$��10,0,0,5q�