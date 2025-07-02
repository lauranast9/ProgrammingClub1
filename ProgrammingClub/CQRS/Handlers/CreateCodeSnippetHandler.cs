using MediatR;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.DataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Handlers
{
    public class CreateCodeSnippetHandler : IRequestHandler<CreateCodeSnippetCommand, Guid>
    {
        private readonly ProgrammingClubDataContext _context;

        public CreateCodeSnippetHandler(ProgrammingClubDataContext context)
        {
            _context = context;
        }


        public async Task<Guid> Handle(CreateCodeSnippetCommand request, CancellationToken cancellationToken)
        {
            var codeSnippet = new CodeSnippet
            {
                IdCodeSnippet = Guid.NewGuid(),
                Title = request.Dto.Title,
                ContentCode = request.Dto.ContentCode,
                IdMember = Guid.NewGuid(),
                Revision = request.Dto.Revision,
                IdSnippetPreviousVersion = Guid.NewGuid(),
                DateTimeAdded = request.Dto.DateTimeAdded,
                IsPublished = request.Dto.IsPublished
            };

            _context.CodeSnippets.Add(codeSnippet);
            await _context.SaveChangesAsync(cancellationToken);
            return codeSnippet.IdCodeSnippet;
        }
    }
}