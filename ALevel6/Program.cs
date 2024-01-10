using System;
using System.IO;

namespace ALevel6
{
    namespace ConsoleApp2
    {
        public class Logger
        {
            private static Logger instance;
            private string logText;

            public static Logger GetInstance()
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }

            public void GetLogger(string logType, string message)
            {
                string logTime = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                string registration = $"{logTime}: {logType}: {message}";
                Console.WriteLine(registration);
                logText += registration;
            }

            public void SaveLogToFail(string fileName)
            {
                File.WriteAllText(fileName, logText);
            }
        }

        public class Result
        {
            public bool Status { get; set; }
            public string Error { get; set; }
        }

        public class Actions
        {
            private Logger logger;

            public Actions()
            {
                logger = Logger.GetInstance();
            }

            public Result StartMetod()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                logger.GetLogger("Start Metod", "Info: ");
                return new Result { Status = true };
            }
            public Result WarningMetod()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                logger.GetLogger("Skipped logic in method", "Warning");
                return new Result { Status = true };
            }

            public Result ErrorMetod()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                logger.GetLogger("I broke a logic", "Error");
                return new Result { Status = false };
            }
        }

        public class Starter
        {
            public void Run()
            {
                Actions actions = new Actions();
                Logger logger = Logger.GetInstance();

                Random rand = new Random();

                for (int i = 0; i < 100; i++)
                {
                    int randomNumber = rand.Next(1, 4);

                    Result result = null;

                    switch (randomNumber)
                    {
                        case 1:
                            result = actions.StartMetod();
                            break;
                        case 2:
                            result = actions.WarningMetod();
                            break;
                        case 3:
                            result = actions.ErrorMetod();
                            break;
                    }

                    if (!result.Status)
                    {
                        logger.GetLogger($"The action wes not completed due to: {result.Error}", "Error");
                    }

                    logger.SaveLogToFail("log.txt");
                }

            }
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Starter starter = new Starter();
                starter.Run();
            }
        }
    }
}
