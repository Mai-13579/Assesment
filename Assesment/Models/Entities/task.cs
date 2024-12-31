using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models.Entities
{
    public class task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public int Projectid {  get; set; }
        [ForeignKey("Projectid")]
        public Project Project { get; set; }
        public int TeamMemberId { get; set; }
        [ForeignKey("TeamMemberId")]
        public TeamMember TeamMember { get; set; }
    }
}
