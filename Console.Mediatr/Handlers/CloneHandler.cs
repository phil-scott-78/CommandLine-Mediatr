using System.IO;
using Console.Mediatr.Verbs;
using MediatR;

namespace Console.Mediatr.Handlers
{
    class CloneHandler : RequestHandler<AddVerb>
    {
        private readonly TextWriter _textWriter;

        public CloneHandler(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected override void HandleCore(AddVerb message)
        {
            _textWriter.WriteLine("cloned {0}", message.FileName);
        }
    }
}