using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Fortnite_Debug_Logger
{
    internal class Program
    {
        private static string Logs = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FortniteGame\\Saved\\Logs\\FortniteGame.log";
        static void Main()
        {
            Process.Start("com.epicgames.launcher://apps/Fortnite?action=launch&silent=false");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Logger";
            if(File.Exists(Logs))
            {
                while (true)
                {
                    StreamReader sr = new StreamReader(File.Open(Logs, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    string readtoend = sr.ReadToEnd();
                    if (readtoend.Length > 1)
                    Console.WriteLine(readtoend);
                    Thread.Sleep(500);
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("[x]: Could not locate logs folder, please make sure you have fortnite installed.");
            Console.ReadLine();
        }
    }
}