using System;
using System.Linq;
using System.Collections.Generic;

using Logger.Core;
using Logger.Factories;
using Logger.Models.Interfaces;


namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            var appenderFactory = new AppenderFactory();
            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Models.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";
                if (appendersInfo.Length == 3)
                {
                   levelStr = appendersInfo[2];
                }

                 
                try
                {
                    IAppender appender = appenderFactory.GetAppender
                        (appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
            }
        }
    }
}
