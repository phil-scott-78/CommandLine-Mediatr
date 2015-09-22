using System.Collections.Generic;
using CommandLine;
using MediatR;

namespace Console.Mediatr.Verbs
{
    [Verb("clone", HelpText = "Clone a repository into a new directory.")]
    public class CloneVerb : IRequest
    {
        [Option("no-hardlinks",
            HelpText = "Optimize the cloning process from a repository on a local filesystem by copying files.")]
        public bool NoHardLinks { get; set; }

        [Option('q', "quiet",
            HelpText = "Suppress summary message.")]
        public bool Quiet { get; set; }

        [Value(0, MetaName = "Urls", HelpText = "The file to add.", Required = true)]
        public IEnumerable<string> Urls { get; set; }
    }
}