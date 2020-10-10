using System;
using System.Threading;
using CommandLine;

namespace loading_bar
{
    class Program
    {
        public class Options
        {
            [Option('p', "prefix", Default = "[", HelpText = "String printed before the loading characters.")]
            public string Prefix { get; set; }

            [Option('s', "suffix", Default = "]", HelpText = "String printed after the loading characters.")]
            public string Suffix { get; set; }

            [Option('c', "characters", Default = "|", HelpText = "String used as a loading bar.")]
            public string LoadingCharacters { get; set; }

            [Option('l', "length", Default = 10, HelpText = "Number of loading bar used.")]
            public int Lenght { get; set; }

            [Option('d', "delai", Default = 10000, HelpText = "Duration in milliseconds of the loading bar.")]
            public int DelaiMs { get; set; }
        }
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options =>
            {
                Console.Write(options.Prefix);
                Console.CursorLeft += options.Lenght * options.LoadingCharacters.Length;
                Console.Write(options.Suffix);
                Console.CursorLeft = options.Prefix.Length;
                for (int i = 0; i < options.Lenght; ++i)
                {
                    Thread.Sleep(options.DelaiMs / options.Lenght);
                    Console.Write(options.LoadingCharacters);
                }
            });
        }
    }
}