using ApartmentMngSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess.DataSeed
{
    internal class MessageSeed : IEntityTypeConfiguration<Message>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Message> builder)
        {
            builder.HasData(new Message
            {
                Id = 1,
                Description = "Faturalar ödendi.",
                UserId = "02174cf0–9412–4cfe-afbf-53422d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 2,
                Description = "Apartman temizlenmemişti.",
                UserId = "02174cf0–9412–4cfe-afbf-53422d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 3,
                Description = "Asansör bozuk, neden ödeme yapıyoruz.",
                UserId = "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 4,
                Description = "Faturalar ödendi.",
                UserId = "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 5,
                Description = "Güvenlik uyuyor.",
                UserId = "02174cf0–9412–4cfe-afbf-591231sd6d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 6,
                Description = "Araçlar özensiz parkediyor, uyarı geçermisiniz? Teşekkürler",
                UserId = "02174cf0–9412–4cfe-afbf-591231sd6d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 7,
                Description = "Pencerelerden halı, örtü silkelenmesin lütfen. Üst kat uyarılarıma rağmen devam ediyor.",
                UserId = "02174cf0–9123xccfe-afbf-59f706d33cf6",
                Status = MessageStatus.NEW

            },
            new Message
            {
                Id = 8,
                Description = "Aidatı ödendi.",
                UserId = "02174cf0–xcvds2e-afbf-59f706d33cf6",
                Status = MessageStatus.NEW

            });
        }
    }
}