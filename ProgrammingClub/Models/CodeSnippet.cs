using System.ComponentModel.DataAnnotations;

namespace ProgrammingClub.Models
{
    public class CodeSnippet
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }
        public string Title {  get; set; }
        public string? ContentCode {  get; set; }
        public Guid IdMember {  get; set; }
        public string Revision {  get; set; }
        public Guid IdSnippetPreviousVersion {  get; set; }
        public string DateTimeAdded {  get; set; }
        public string IsPublished {  get; set; }

    }
}
