namespace Log4NetExample
{
    using System;
    using log4net;
    using log4net.Config;

    internal class Log4NetExample
    {
        private static readonly ILog Log =
          LogManager.GetLogger(typeof(Log4NetExample));

        private static void Main()
        {
            const short COUNTER = 21;

            BasicConfigurator.Configure();

            for (int i = 0; i < COUNTER; i++)
            {
                Log.Info("Logging success number - " + i);

                if (i > 17)
                {
                    Log.Error("Timw to stop .");
                    throw new NotImplementedException("Test");
                }
            }
        }
    }
}