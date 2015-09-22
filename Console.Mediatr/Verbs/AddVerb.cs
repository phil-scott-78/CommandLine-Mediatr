using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using MediatR;

namespace Console.Mediatr.Verbs
{
    [Verb("add", HelpText = "Add file contents to the index.")]
    public class AddVerb : IRequest
    {
        [Value(0, MetaName = "File Name", HelpText = "The file to add.", Required = true)]
        public string FileName { get; set; }

        [Option('p', "patch", HelpText = "Interactively choose hunks of patch between the index and the work tree and add them to the index.")]
        public bool Patch { get; set; }

        [Option('f', "force", HelpText = "Allow adding otherwise ignored files.")]
        public bool Force { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new AddVerb { FileName = "file.bin"});
                yield return new Example("Forced ignored files", UnParserSettings.WithGroupSwitchesOnly(), new AddVerb() { FileName = "file.bin", Force = true });
            }
        }
    }
}