using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fclp;

namespace LogFileAnalyser
{

    public class ApplicationArguments
    {
        public string PathContainingLogFilesToAnalyse { get; set; }
        public string OutputFile { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var p = new FluentCommandLineParser<ApplicationArguments>();

            // specify which property the value will be assigned too.
            p.Setup(arg => arg.PathContainingLogFilesToAnalyse)
             .As('s', "source") // define the short and long option name
             .Required(); // using the standard fluent Api to declare this Option as required.

            p.Setup(arg => arg.OutputFile)
                .As('d', "destination")
                .Required();

            p.Parse(args);

            AsyncContext.Run(async () => {
                await AsyncMain(p.Object);
            });
        }

        private static async Task AsyncMain(ApplicationArguments args)
        {
            throw new NotImplementedException();
        }
    }
}
