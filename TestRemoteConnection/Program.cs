using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;

namespace TestRemoteConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем имя локального компьютера
            var hostname = Dns.GetHostName();
            Console.WriteLine($"Hostname: {hostname}");

            // Получаем необходимый раздел реестра
            var hive = RegistryHive.LocalMachine;

            // Подключаемся к этому разделу на удаленном(или локальном) компьютере

            //var regKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry32); // --local 
            var regKey = RegistryKey.OpenRemoteBaseKey(hive, hostname); // --remote тут вместо hostname нужно ввести имя удаленного компьютера

            var subkeys = regKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\").GetSubKeyNames();

            foreach (var subkey in subkeys)
            {
                Console.WriteLine(subkey);
            }
            Console.ReadKey();
        }
    }
}
