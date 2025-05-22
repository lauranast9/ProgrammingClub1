namespace ProgrammingClub.Models
{
    public class Announcemment
    {
        public Guid IdAnnouncemment {  get; set; }
        public string ValidFrom {  get; set; }
        public string ValidTo { get; set; }
        public string Title {  get; set; }
        public string Text {  get; set; }
        public string EventDateTime {  get; set; }
        public string Tags {  get; set; }

   
    }
}
