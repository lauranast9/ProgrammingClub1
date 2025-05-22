namespace ProgrammingClub.Models
{
    public class CodeSnippet
    {
        public Guid IdCodeSnippet { get; set; }
        public string Title {  get; set; }
        public string ContentCode {  get; set; }
        public string IdMember {  get; set; }
        public string Revision {  get; set; }
        public string IdSnippetPreviousVersion {  get; set; }
        public string DateTimeAdded {  get; set; }
        public string IsPublished {  get; set; }

    }
}
