using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AppInformer
{
    public static class RegistryConnection
    {
        public static async Task<Hashtable[]> GetAppsAsync(string hostname)
        {
            return await Task.Run(() =>
            {
                try
                {
                    const string MainKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
                    const string AppNameLine = "DisplayName";
                    const string AppVersionLine = "DisplayVersion";


                    // Получаем имя локального компьютера если другого не указано
                    if (String.IsNullOrEmpty(hostname))
                    {
                        hostname = Dns.GetHostName();
                    }

                    // Получаем необходимый раздел реестра
                    var hive = RegistryHive.LocalMachine;

                    // Подключаемся к этому разделу на удаленном(или локальном) компьютере
                    //var regKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry32); // --local 
                    var regKey = RegistryKey.OpenRemoteBaseKey(hive, hostname); // --remote тут вместо hostname нужно ввести имя удаленного компьютера

                    // Получаем имена всех подразделов раздела SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ (каждый подраздел --- приложение)
                    var subkeys = regKey.OpenSubKey(MainKeyPath).GetSubKeyNames();
                    List<Hashtable> apps = new List<Hashtable>();
                    for (int i = 0; i < subkeys.Length; i++)
                    {
                        var appKey = regKey.OpenSubKey(MainKeyPath + subkeys[i]);
                        if (appKey.GetValue(AppNameLine) == null)
                        {
                            continue;
                        }
                        var table = new Hashtable();
                        foreach (var valueName in appKey.GetValueNames())
                        {
                            if (valueName == AppNameLine)
                            {
                                table.Add(AppNameLine, appKey.GetValue(AppNameLine));
                            }
                            else if (valueName == AppVersionLine)
                            {
                                table.Add(AppVersionLine, appKey.GetValue(AppVersionLine));
                            }
                        }
                        apps.Add(table);
                    }

                    return apps.ToArray();
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            });
        }
    }
}
