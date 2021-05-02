using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInformer
{
    public static class NetworkHelper
    {
        public static async Task<string[]> GetLocalNamesAsync()
        {
            return await Task.Run(() =>
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
                        list.Add(strs[i].Remove(0, 2));
                    }
                }

                return list.ToArray();
            });
        }
    }
}
