# ApartmentMngSystem

# Siteniz İçin Yönetim Sistemi

Bu proje, bir site yönetiminin ihtiyaçlarını karşılamak üzere tasarlanmış bir .NET web uygulamasıdır. Sistem, site yöneticilerinin ve sakinlerinin daire bilgilerini, aylık aidat ve fatura bilgilerini yönetmelerini, ayrıca site sakinlerinin aidat ve faturalarını kredi kartı ile ödemelerini sağlar.

## Özellikler

### Admin/Yönetici
- **Daire Bilgileri:** Blok, durum, tip, kat, daire numarası, daire sahibi veya kiracı.
- **Kullanıcı Bilgileri:** Ad-soyad, TC No, E-Mail, Telefon, Araç bilgisi.
- **Aidat ve Fatura Yönetimi:** Ay bazlı olarak ekleme ve düzenleme.
- **Mesajlaşma:** Okunmuş/okunmamış/yeni mesaj durumu.
- **Borç-Alacak Listesi:** Aylık görüntüleme.
- **Düzenleme ve Silme İşlemleri:** Kişi ve daire bilgileri üzerinde.
- **Günlük Mail Gönderimi:** Fatura ödemeyen kişilere.

### Kullanıcı
- **Fatura ve Aidat Görüntüleme:** Kendisine atanan bilgiler.
- **Ödeme Yapma:** Sadece kredi kartı ile.
- **Yöneticiye Mesaj Gönderme**

## Teknolojiler
- **Backend:** .NET [.Net 6] - .net library
- **Database:** MS SQL Server
- **Dökümantasyon:** Postman, Swagger
- Project uses below libraries and tech stack
- [.Net Identity] - for user authentication and authorization
- [Hangfire] - Recurring job to send email
- [MailKit] - To send email to users periodically
- [PasswordGenerator] - Standart password generator library

# Username: apartmentmanagementsystemtest@gmail.com
# Password": Apartment123
