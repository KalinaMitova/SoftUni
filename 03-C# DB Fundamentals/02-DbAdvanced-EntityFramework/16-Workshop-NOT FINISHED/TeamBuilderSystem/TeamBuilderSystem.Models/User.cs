namespace TeamBuilderSystem.Models
{
    using System;

    using TeamBuilderSystem.Models.Enums;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
