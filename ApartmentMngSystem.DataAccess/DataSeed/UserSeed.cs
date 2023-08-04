using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentMngSystem.DataAccess.DataSeed
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Yaprak",
                LastName = "Yildirim",
                IdentityNumber = "14975856297",
                PhoneNumber = "5417894512",
                PlateNumber = "34NV3128",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.PasswordHash = ph.HashPassword(user, "admin");
            builder.HasData(user);

            builder.HasData(new User
            {
                Id = "02174cf0–9412–4cfe-afbf-53422d33cf6",
                Email = "cemgunveren@hotmail.com",
                NormalizedEmail = "CEMGUNVEREN@HOTMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Cem",
                LastName = "Gunveren",
                IdentityNumber = "35898714563",
                PhoneNumber = "5300708998",
                PlateNumber = "34FV07",
                UserName = "user2",
                PasswordHash = ph.HashPassword(user, "test"),
                NormalizedUserName = "USER2"
            },
            new User
            {
                Id = "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6",
                Email = "yusuf@gmail.com",
                NormalizedEmail = "YUSUF@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Yusuf",
                LastName = "Aslan",
                IdentityNumber = "15178945632",
                PhoneNumber = "5329638956",
                PlateNumber = "34BFF44",
                UserName = "user3",
                PasswordHash = ph.HashPassword(user, "test"),
                NormalizedUserName = "USER3"
            },
            new User
            {
                Id = "02174cf0–9412–4cfe-afbf-591231sd6d33cf6",
                Email = "furkankucukali@outlook.com",
                NormalizedEmail = "FURKANKUCUKALI@OUTLOOK.COM",
                EmailConfirmed = true,
                FirstName = "Furkan",
                LastName = "Kucukali",
                IdentityNumber = "17898774123",
                PhoneNumber = "5329665632",
                PlateNumber = "34CV78",
                UserName = "user4",
                NormalizedUserName = "USER4",
                PasswordHash = ph.HashPassword(user, "test")
            },
            new User
            {
                Id = "02174cf0–9123xccfe-afbf-59f706d33cf6",
                Email = "busraozdemir@gmail.com",
                NormalizedEmail = "BUSRAOZDEMIR@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Busra",
                LastName = "Ozdemir",
                IdentityNumber = "14798756332",
                PhoneNumber = "5417894125",
                PlateNumber = "34ZH45",
                UserName = "user5",
                NormalizedUserName = "USER5",
                PasswordHash = ph.HashPassword(user, "test")
            },
            new User
            {
                Id = "02174cf0–9cvbcds2-afbf-59f706d33cf6",
                Email = "ayselshn@gmail.com",
                NormalizedEmail = "AYSELSHN@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Aysel",
                LastName = "Sahin",
                IdentityNumber = "452256565623",
                PhoneNumber = "5453500023",
                PlateNumber = "34SHN58",
                UserName = "user6",
                NormalizedUserName = "USER6",
                PasswordHash = ph.HashPassword(user, "test")
            },
            new User
            {
                Id = "02174cf0–xcvds2e-afbf-59f706d33cf6",
                Email = "altun58@gmail.com",
                NormalizedEmail = "ALTUN58@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Altun",
                LastName = "Yıldıran",
                IdentityNumber = "14978889789",
                PhoneNumber = "5354869874",
                PlateNumber = "34AY78",
                UserName = "user7",
                NormalizedUserName = "USER7",
                PasswordHash = ph.HashPassword(user, "test")
            });
        }
    }
}
