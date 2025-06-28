using System.ComponentModel.DataAnnotations;

namespace ProgrammingClub.Models
{
    public class Membership
    {
        [Key]
        public Guid IdMembership { get; set; }
        public string IdMember {  get; set; }
        public string IdMembershipType {  get; set; }
        public string StartDate {  get; set; }
        public string EndDate { get; set; }
        public string Level {  get; set; }
    }
}
