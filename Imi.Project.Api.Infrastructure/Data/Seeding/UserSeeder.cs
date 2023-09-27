using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding;

public class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();

        modelBuilder.Entity<IdentityRole>()
                    .HasData(new IdentityRole
                    {
                        Id = "00000000-0000-0000-0000-000000000001",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
);

        modelBuilder.Entity<IdentityRole>()
                    .HasData(new IdentityRole
                    {
                        Id = "00000000-0000-0000-0000-000000000002",
                        Name = "User",
                        NormalizedName = "USER"
                    }
);

        var imiUser = new User
        {
            Id = "00000000-0000-0000-0000-000000000001",
            UserName = "ImiUser",
            NormalizedUserName = "IMIUSER",
            Email = "user@imi.be",
            NormalizedEmail = "USER@IMI.BE",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        imiUser.PasswordHash = passwordHasher.HashPassword(imiUser, "Test123?");
        modelBuilder.Entity<User>().HasData(imiUser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = imiUser.Id
        });

        var imiRefuser = new User
        {
            Id = "00000000-0000-0000-0000-000000000002",
            UserName = "ImiRefuser",
            NormalizedUserName = "IMIREFUSER",
            Email = "refuser@imi.be",
            NormalizedEmail = "REFUSER@IMI.BE",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = false
        };

        imiRefuser.PasswordHash = passwordHasher.HashPassword(imiRefuser, "Test123?");
        modelBuilder.Entity<User>().HasData(imiRefuser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = imiRefuser.Id
        });

        var imiAdmin = new User
        {
            Id = "00000000-0000-0000-0000-000000000003",
            UserName = "ImiAdmin",
            NormalizedUserName = "IMIADMIN",
            Email = "admin@imi.be",
            NormalizedEmail = "ADMIN@IMI.BE",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true
        };

        imiAdmin.PasswordHash = passwordHasher.HashPassword(imiAdmin, "Test123?");
        modelBuilder.Entity<User>().HasData(imiAdmin);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000001",
            UserId = imiAdmin.Id
        });

        var user4 = new User
        {
            Id = "00000000-0000-0000-0000-000000000004",
            UserName = "Yusifer",
            NormalizedUserName = "YUSIFER",
            Email = "woutercallewaert@gmail.com",
            NormalizedEmail = "WOUTERCALLEWAERT@GMAIL.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user4.PasswordHash = passwordHasher.HashPassword(user4, "Test123?");
        modelBuilder.Entity<User>().HasData(user4);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000001",
            UserId = user4.Id
        });

        var user5 = new User
        {
            Id = "00000000-0000-0000-0000-000000000005",
            UserName = "Alice",
            NormalizedUserName = "ALICE",
            Email = "alice@example.com",
            NormalizedEmail = "ALICE@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user5.PasswordHash = passwordHasher.HashPassword(user5, "Password123?");
        modelBuilder.Entity<User>().HasData(user5);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user5.Id
        });

        var user6 = new User
        {
            Id = "00000000-0000-0000-0000-000000000006",
            UserName = "Bob",
            NormalizedUserName = "BOB",
            Email = "bob@example.com",
            NormalizedEmail = "BOB@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user6.PasswordHash = passwordHasher.HashPassword(user6, "Password123?");
        modelBuilder.Entity<User>().HasData(user6);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user6.Id
        });

        var user7 = new User
        {
            Id = "00000000-0000-0000-0000-000000000007",
            UserName = "Charlie",
            NormalizedUserName = "CHARLIE",
            Email = "charlie@example.com",
            NormalizedEmail = "CHARLIE@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user7.PasswordHash = passwordHasher.HashPassword(user7, "Password123?");
        modelBuilder.Entity<User>().HasData(user7);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user7.Id
        });

        var user8 = new User
        {
            Id = "00000000-0000-0000-0000-000000000008",
            UserName = "David",
            NormalizedUserName = "DAVID",
            Email = "david@example.com",
            NormalizedEmail = "DAVID@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user8.PasswordHash = passwordHasher.HashPassword(user8, "Password123?");
        modelBuilder.Entity<User>().HasData(user8);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user8.Id
        });

        var user9 = new User
        {
            Id = "00000000-0000-0000-0000-000000000009",
            UserName = "Eva",
            NormalizedUserName = "EVA",
            Email = "eva@example.com",
            NormalizedEmail = "EVA@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user9.PasswordHash = passwordHasher.HashPassword(user9, "Password123?");
        modelBuilder.Entity<User>().HasData(user9);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user9.Id
        });

        var user10 = new User
        {
            Id = "00000000-0000-0000-0000-000000000010",
            UserName = "Fiona",
            NormalizedUserName = "FIONA",
            Email = "fiona@example.com",
            NormalizedEmail = "FIONA@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            HasApprovedTermsAndConditions = true
        };

        user10.PasswordHash = passwordHasher.HashPassword(user10, "Password123?");
        modelBuilder.Entity<User>().HasData(user10);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "00000000-0000-0000-0000-000000000002",
            UserId = user10.Id
        });

    }
}
