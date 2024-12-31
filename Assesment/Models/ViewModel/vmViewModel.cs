using Assesment.Models.Entities;

namespace Assesment.Models.ViewModel
{
    public class vmViewModel
    {
        public int Id { get; set; }
        public int ProjectId {  get; set; }
        public string Name { get; set; }
        public string status {  get; set; }
        public string priority {  get; set; }
        public DateTime DeadLine { get; set; }

        public int MembersId { get; set; }
        public List<Project> projects { get; set; }
        public List<TeamMember> members { get; set; }


    }
}
