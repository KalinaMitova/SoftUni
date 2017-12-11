namespace TeamBuilderSystem.Models
{
    using System;

    public class UserTeam
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TeamId { get; set; }
        public User Team { get; set; }
    }
}
