using System;
using System.Collections.Generic;
using CommandLine;
using PSCBuddy.Behaviors.Utils;
using PSCBuddy.Behaviors.Utils.Systems;

namespace archive2chd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(HandleOptions)
                .WithNotParsed(HandleParseError);
        }

        private static void HandleOptions(Options opts)
        {
            var log = opts.Verbose ? (Action<string>) Console.WriteLine : s => { };
            
            var gic = new GameInstallCoordinator(NullPlaylistManager.Instance, GetSystem(opts.System));
            gic.ArchiveToCHD(opts.CHDManPath, opts.SevenZPath, opts.ArchivePath, opts.ForceCueCreate,
                opts.TargetDirectory, opts.Cleanup, log);
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var err in errs)
            {
                Console.Error.WriteLine(err);
            }
            
            Environment.Exit(1);
        }

        private static ISystem GetSystem(string input)
        {
            switch (input)
            {
                case "psx":
                    return Playstation.Instance;
                case "pce":
                    return PCEngineCD.Instance;
                default:
                    return GenericSystem.Instance;
            }
        }
    }
}