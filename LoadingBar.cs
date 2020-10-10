using System;
using System.Threading;
using CommandLine;

namespace loading_bar
{
    class LoadingBar
    {
        public class Options
        {
            [Option('o', Required = false, HelpText = "Name of the operation needing loading, printed before the prefix.")]
            public string Operation { get; set; }

            [Option('f', "finished", Required = false, HelpText = "String printed when the loading is over")]
            public string EndMessage { get; set; }

            [Option('p', Default = "[", HelpText = "String printed before the loading characters.")]
            public string Prefix { get; set; }

            [Option('s', Default = "]", HelpText = "String printed after the loading characters.")]
            public string Suffix { get; set; }

            [Option('c', "characters", Default = "|", HelpText = "String used as a loading bar.")]
            public string LoadingCharacters { get; set; }

            [Option('l', Default = 10, HelpText = "Number of loading bar used.")]
            public int Lenght { get; set; }

            [Option('d', "delai", Default = 10000, HelpText = "Duration in milliseconds of the loading bar.")]
            public int DelaiMs { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options =>
            {
                int loading_bar_begin_pos = options.Prefix.Length;
                if (options.Operation != null)
                {
                    Console.Write(options.Operation);
                    Console.Write(": ");
                    loading_bar_begin_pos += options.Operation.Length + 2;
                }

                Console.Write(options.Prefix);
                Console.CursorLeft += options.Lenght * options.LoadingCharacters.Length;
                Console.Write(options.Suffix);
                
                Console.CursorLeft = loading_bar_begin_pos;
                for (int i = 0; i < options.Lenght; ++i)
                {
                    Thread.Sleep(options.DelaiMs / options.Lenght);
                    Console.Write(options.LoadingCharacters);
                }

                if (options.EndMessage != null)
                {
                    Console.CursorLeft += options.Suffix.Length;
                    Console.Write(options.EndMessage);
                }
            });
        }
    }
}