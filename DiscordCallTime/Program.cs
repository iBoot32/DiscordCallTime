using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCallTime
{
    class Program
    {

        /**
         *  DiscordCallTime
         *      A program that analyzes your Discord
         *      DMs to determine just how long you've spent
         *      in a Discord call with someone.... ever.
         *      
         *      Simply download your DMS using "DiscordChatExporter"
         *      and run this program:
         *      
         *      DiscordCallTime.exe "<dm.html location>"
         */


        public static string loc;
        public static string first;
        public static string final;
        public static Double time;
        public static int lineCount;
        public static Double callTime;

        static void Main(string[] args)
        {
            loc = args[0];

            var lines = File.ReadLines(loc);
            foreach (var line in lines)
            {
                if (line.Contains("Started a call that lasted"))
                {
                    lineCount += 1;
                    first = line.Substring(line.IndexOf("lasted ") + 7);
                    final = first.Remove(first.LastIndexOf(" minutes."));

                    time = Double.Parse(final);

                    callTime += time;
                    
                }
            }

            Console.WriteLine(Environment.NewLine + "Out of " + lineCount + " total calls, your total call time with this user is " + callTime + " minutes");
            Console.WriteLine("Which is equal to " + callTime / 60 + " hours or " + callTime / 60 / 24 + " days");
            Console.WriteLine("Congrats!");
        }
    }
}
