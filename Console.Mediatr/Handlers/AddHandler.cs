using System.IO;
using Console.Mediatr.Verbs;
using MediatR;

namespace Console.Mediatr.Handlers
{
    class AddHandler : RequestHandler<AddVerb>
    {
        private readonly TextWriter _textWriter;

        public AddHandler(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected override void HandleCore(AddVerb message)
        {
            _textWriter.WriteLine("added {0}. Forced: {1}. Patch {2}", message.FileName, message.Force, message.Patch);
        }
    }
}