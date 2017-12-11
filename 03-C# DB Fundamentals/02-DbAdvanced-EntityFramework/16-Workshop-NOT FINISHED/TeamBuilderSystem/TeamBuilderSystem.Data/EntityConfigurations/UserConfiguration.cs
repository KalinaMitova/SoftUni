namespace TeamBuilderSystem.Data.EntityConfigurations
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using TeamBuilderSystem.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

        }
    }
}
