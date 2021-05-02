using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Collections;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace TestRemoteConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetLocalAddress();
            GetLocalNames();
            Console.ReadLine();
        }

        public static void GetLocalNames()
        {
            ProcessStartInfo cmdproc = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c net view",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var result = Process.Start(cmdproc).StandardOutput.ReadToEnd();
            var strs = result.Split(" .,\n\r".ToCharArray());
            List<string> list = new List<string>();
            for (int i = 0; i < strs.Length; i++)
            {
                if (String.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].StartsWith("\\"))
                {
                    list.Add(strs[i]);
                }
            }
            var lsar = list.ToArray();
            Console.WriteLine(result);
        }

        public static void GetLocalAddress()
        {
            // доступно ли сетевое подключение
            if (!NetworkInterface.GetIsNetworkAvailable())
                return;
            // запросить у DNS-сервера IP-адрес, связанный с именем узла
            var host = Dns.GetHostEntry(Dns.GetHostName());
            // Пройдем по списку IP-адресов, связанных с узлом
            foreach (var ip in host.AddressList)
            {
                // если текущий IP-адрес версии IPv4, то выведем его
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                }
            }
        }

        private static void ShowHashTable(Hashtable hashTable, string title)
        {
            // Проверяем входные аргументы.
            if (hashTable == null)
            {
                throw new ArgumentNullException(nameof(hashTable));
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            // Выводим все имеющие пары хеш-значение
            Console.WriteLine(title);
            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine($"\t{key} --- {hashTable[key]}");
            }
            Console.WriteLine();
        }

        private void GetRemote()
        {
            const string MainKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
            const string AppName = "DisplayName";
            const string AppVersion = "DisplayVersion";


            // Получаем имя локального компьютера
            var hostname = Dns.GetHostName();
            Console.WriteLine($"Hostname: {hostname}");

            // Получаем необходимый раздел реестра
            var hive = RegistryHive.LocalMachine;

            // Подключаемся к этому разделу на удаленном(или локальном) компьютере
            //var regKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry32); // --local 
            var regKey = RegistryKey.OpenRemoteBaseKey(hive, hostname); // --remote тут вместо hostname нужно ввести имя удаленного компьютера

            // Получаем имена всех подразделов раздела SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ (каждый подраздел --- приложение)
            var subkeys = regKey.OpenSubKey(MainKeyPath).GetSubKeyNames();
            Hashtable[] apps = new Hashtable[subkeys.Length];
            for (int i = 0; i < subkeys.Length; i++)
            {
                apps[i] = new Hashtable();
                var appKey = regKey.OpenSubKey(MainKeyPath + subkeys[i]);
                foreach (var valueName in appKey.GetValueNames())
                {
                    if (valueName == AppName)
                    {
                        apps[i].Add(AppName, appKey.GetValue(AppName));
                        //Console.WriteLine(valueName + " " + appKey.GetValue(valueName));
                    }
                    else if (valueName == AppVersion)
                    {
                        apps[i].Add(AppVersion, appKey.GetValue(AppVersion));
                        //Console.WriteLine(valueName + " " + appKey.GetValue(valueName));
                    }
                }
            }
            foreach (var table in apps)
                ShowHashTable(table, " Table");
        }
    }
}
