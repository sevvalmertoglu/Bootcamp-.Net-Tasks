# Kütüphane Yönetim Sistemi Web Uygulaması

Bu proje, temel bir Kütüphane Yönetim Sistemi web uygulamasıdır. Kitaplarla ilgili CRUD işlemlerini gerçekleştirmenize olanak sağlar. Uygulama, Entity Framework Core kullanılarak .NET platformunda geliştirilmiş ve SQLite veritabanı ile entegre edilmiştir.

## Uygulamanın Temel Özellikleri:
- Kitap Listeleme: Sistemde mevcut tüm kitapların bir tablo halinde listelenmesi.
- Kitap Detayları: Belirli bir kitabın ayrıntılı bilgilerini görüntüleme.
- Kitap Ekleme: Yeni kitapların eklenmesi için form.
- Kitap Güncelleme: Mevcut kitapların bilgilerinin düzenlenmesi.
- Kitap Silme: Kitapların sistemden silinmesi.

## Kullanılan Teknolojiler ve Mimari
- Backend: ASP.NET Core
- Veritabanı: SQLite
- ORM: Entity Framework Core
- Mimari Desenler: Repository Pattern ve UnitOfWork Pattern.

## Kullanılan Teknolojiler ve Mimari
- Backend: ASP.NET Core
- Veritabanı: SQLite
- ORM: Entity Framework Core
- Mimari Desenler: Repository Pattern ve UnitOfWork Pattern

## Proje Yapısı
- Models: Uygulamanın veri modellerini içerir.
- Repositories: Veritabanı işlemleri için Repository Pattern uygulanmıştır.
- UnitOfWork: Tüm işlemlerin tek bir context üzerinden yönetilmesi sağlanmıştır.
- Controllers: API isteklerini işler.
- Views: Kullanıcıya sunulan HTML/CSS tabanlı arayüz.
