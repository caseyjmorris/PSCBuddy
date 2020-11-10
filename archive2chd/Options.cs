using CommandLine;

namespace archive2chd
{
    public class Options
    {
        // string chdmanPath, string sevenZPath, string archivePath, bool forceCueCreate,
        //string targetDirectory, bool cleanup, Action<string> logConsoleOutput)
        [Option('c', "chdman-path", Required = true, HelpText = "Path to chdman")]
        public string CHDManPath { get; set; }
        [Option('z', "7z-path", Required = true, HelpText = "Path to 7z")]
        public string SevenZPath { get; set; }
        [Option('i', "input", Required = true, HelpText = "Archive to convert")]
        public string ArchivePath { get; set; }
        [Option('f', "force-cue-create", HelpText = "Create a new cue instead of using the existing one")]
        public bool ForceCueCreate { get; set; }
        [Option('o', "output-directory", HelpText = "Directory to output chd to")]
        public string TargetDirectory { get; set; }
        [Option('c', "cleanup", Default = true, HelpText = "Remove extracted files")]
        public bool Cleanup { get; set; }
        [Option('v', "verbose")]
        public bool Verbose { get; set; }
        [Option('s', "system", Default = "other")]
        public string System { get; set; }
    }
}