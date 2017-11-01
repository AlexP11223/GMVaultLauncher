[![Build status](https://ci.appveyor.com/api/projects/status/4jukt0vrj7unosd1/branch/master?svg=true)](https://ci.appveyor.com/project/AlexP11223/gmvaultlauncher/branch/master)

A simple C# Windows app that can be used for launching any console app and saving output to a file, without showing any window.

I used it for backing up my GMail daily with [Gmvault](http://gmvault.org) (via Task Scheduler as suggested here: [https://www.hanselman.com/blog/AutomaticallyBackupYourGmailAccountOnAScheduleWithGMVaultAndWindowsTaskScheduler.aspx](https://www.hanselman.com/blog/AutomaticallyBackupYourGmailAccountOnAScheduleWithGMVaultAndWindowsTaskScheduler.aspx)).

Of course it can be implemented via a script, for example PowerShell, but I decided that C# would be easier to test and I like it more :) Also I am not sure if there is a simple way to hide PowerShell window so it would not flash every day.

Usage:

```
GMVaultLauncher app_path log_dir args
```

Example:

```
GMVaultLauncher gmvault.bat logs\ sync -t quick name@gmail.com -e
```
