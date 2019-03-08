using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horker.Logger;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempFile = Path.GetTempFileName();
            Console.WriteLine(tempFile);
            using (var logger = new JsonLogger(tempFile, false, "test"))
            {
                logger.Info(1234);
                logger.Info(new double[] { 1.2, 3.4, 5.6 });
                logger.Info(new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }});

                logger.Fatal("something\nwrong\nhappened", "Fatal message");

                try
                {
                    throw new ApplicationException("application exception");
                }
                catch (Exception e)
                {
                    logger.Debug(e);
                }

                var dir = new DirectoryInfo("C:\\Windows");
                logger.Debug(dir);
            }

            using (var reader = new StreamReader(tempFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Console.Write("Push Enter to exit.");
            Console.ReadLine();
        }
    }
}
