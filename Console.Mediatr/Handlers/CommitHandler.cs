using System.IO;
using Console.Mediatr.Verbs;
using MediatR;

namespace Console.Mediatr.Handlers
{
    class CommitHandler : RequestHandler<AddVerb>
    {
        private readonly TextWriter _textWriter;

        public CommitHandler(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected override void HandleCore(AddVerb message)
        {
            _textWriter.WriteLine("committed {0}", message.FileName);
        }
    }
}