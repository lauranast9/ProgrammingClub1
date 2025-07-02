namespace ProgrammingClub.CQRS.DTOs
{
    public class CodeSnippetDto
    {
        public string? Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IDMember { get; set; }
        public string Revision { get; set; }
        public Guid IDSnippetPreviousVersion { get; set; }
        public string DateTimeAdded { get; set; }
        public string IsPublished { get; set; }
    }
}