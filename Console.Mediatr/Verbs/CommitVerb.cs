using CommandLine;
using MediatR;

namespace Console.Mediatr.Verbs
{
    [Verb("commit", HelpText = "Record changes to the repository.")]
    public class CommitVerb : IRequest
    {
        [Option('p', "patch",
            HelpText = "Use the interactive patch selection interface to chose which changes to commit.")]
        public bool Patch { get; set; }

        [Option("amend", HelpText = "Used to amend the tip of the current branch.")]
        public bool Amend { get; set; }

        [Option('m', "message", HelpText = "Use the given message as the commit message.")]
        public string Message { get; set; }
    }
}