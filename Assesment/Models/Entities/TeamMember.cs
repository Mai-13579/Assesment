﻿namespace Assesment.Models.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string Role { get; set; }
        public List<task>tasks { get; set; }
    }
}