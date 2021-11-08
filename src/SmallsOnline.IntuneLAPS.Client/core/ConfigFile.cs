using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using SmallsOnline.IntuneLAPS.Lib.Helpers;
using SmallsOnline.IntuneLAPS.Lib.Models.Config;

namespace SmallsOnline.IntuneLAPS.Client.Core
{
    public static class ConfigFile
    {
        private static readonly string _configFilePath = Path.Join(Environment.CurrentDirectory, "config.json");

        public static LAPSConfig GetConfig()
        {
            Task<string> getConfigFileTask = Task.Run(() => GetConfigFileContents());
            Task.WaitAll(getConfigFileTask);
            string configFileContents = getConfigFileTask.Result;

            LAPSConfig config = JsonConverterHelper.ConvertFromJson<LAPSConfig>(configFileContents);

            return config;
        }

        private static async Task<string> GetConfigFileContents()
        {
            string configFileContents;

            FileInfo configFile = new(_configFilePath);
            using (StreamReader streamReader = new(configFile.Open(FileMode.Open, FileAccess.Read)))
            {
                configFileContents = await streamReader.ReadToEndAsync();
            }

            return configFileContents;
        }
    }
}