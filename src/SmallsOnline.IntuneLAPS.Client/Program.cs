using System;
using System.Collections.Generic;

using SmallsOnline.IntuneLAPS.Client.Core;
using SmallsOnline.IntuneLAPS.Lib.Models.Config;

namespace SmallsOnline.IntuneLAPS.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> _args = new(args);
            LAPSConfig config = ConfigFile.GetConfig();

            Console.WriteLine($"Server: {config.LAPSUri}");
            Console.WriteLine($"Max Password Age: {config.MaxPasswordAge} days");
            Console.WriteLine($"Local Admin Username: {config.LocalAdminUserName}");

            LocalAdminAccount localAdmin = new(config.LocalAdminUserName);
            Console.WriteLine("Found local admin user.");

            if (localAdmin.IsPasswordExpired(config.MaxPasswordAge) || _args.Contains("--force"))
            {
                string newPwd = PasswordGenerator.CreatePassword_String(18, null, true);
                localAdmin.UpdateAccountPassword(newPwd);

                ServerClient serverClient = new(config);
                serverClient.UpdateAccountPassword(newPwd);
                serverClient.Dispose();

                Console.WriteLine("Password successfully updated.");
            }
            else
            {
                Console.WriteLine("Password is still valid.");
            }
        }
    }
}
