using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInformer
{
    public static class PSScriptStorage
    {
        public static string GetCommand(string state)
        {
            switch(state)
            {
                case "Registry":
                    return @"Get-ItemProperty HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\* |  sort -property DisplayName | Select-Object DisplayName, DisplayVersion, Publisher, InstallDate | Format-Table -AutoSize";
                case "Wmi":
                    return @"Get-WmiObject -class win32_product | sort -Descending -Property Name, Version";
                case "Test":
                    return @"Get-Process | select-object -First 100";
                case "Export":
                    return @"Export-Csv -Path AppsTable.csv";
                default:
                    return @"Get-ChildItem -Path 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\' | `
    Get-ItemProperty | Select DisplayName, DisplayVersion";
            }
        }
    }
}
