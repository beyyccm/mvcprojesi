# LibraryMVC — Kütüphane Yönetim Sistemi (ASP.NET Core MVC)

## Nasıl Çalıştırılır
1. **Gereksinimler**: .NET 8 SDK (https://dotnet.microsoft.com/)
2. Proje klasörüne gidin:
   ```bash
   cd LibraryMVC
   dotnet restore
   dotnet run
   ```
3. Tarayıcıdan `https://localhost:5001` veya konsoldaki adresi açın.

## Mimari ve Yapı
- **OOP**: `Models` (Book, Author) + `Services` (Repository Arayüzleri ve InMemory Uygulamaları) + DI (Program.cs içi `AddSingleton`).
- **ViewModel**: `ViewModels/BookViewModel.cs`, `AuthorViewModel.cs`, `BookFormViewModel.cs`.
- **Controller**: `BookController`, `AuthorController`, `HomeController`.
- **View**: Layout (`Views/Shared/_Layout.cshtml`), PartialView (`_Footer.cshtml`, `_ValidationScriptsPartial.cshtml`), sayfalar (List/Details/Create/Edit/Delete).
- **wwwroot**: Statik dosyalar (`css/site.css`) — footer sabitlenmiştir.
- **Routing**: Varsayılan rota `{controller=Home}/{action=Index}/{id?}`.
- **Sayfalar**: Ana Sayfa (`Home/Index`), Hakkında (`Home/About`).

## Test Senaryoları
- **Kitap CRUD**: Kitap ekle → listeyi kontrol et → detayını görüntüle → düzenle → listeden *Sil* butonu ile veya onay sayfasından sil.
- **Yazar CRUD**: Yazar ekle → listele → düzenle → sil. Kitap formunda yazar seçimi açılır liste ile yapılır.
- **Doğrulama**: Zorunlu alanlar ve sayı aralıkları DataAnnotations ile sağlanır. İstemci tarafı doğrulama `_ValidationScriptsPartial` ile aktiftir.

## Notlar
- Veri deposu **in-memory**’dir; uygulama her başlatıldığında örnek veriler yeniden yüklenir.
- Gerçek DB isterseniz Entity Framework Core ile `ApplicationDbContext` ekleyip Repository’leri EF ile uyarlayabilirsiniz.

## Proje Gereksinimleri Eşlemesi
- **Model**: Book, Author ✔️
- **ViewModel**: BookViewModel, AuthorViewModel, BookFormViewModel ✔️
- **Controller Aksiyonları**: List, Details, Create, Edit, Delete (onay sayfası) + listeden silme butonu ✔️
- **Views**: İlgili tüm sayfalar ✔️
- **Program.cs**: MVC servisleri, statik dosyalar (wwwroot), routing ve varsayılan route ✔️
- **Layout & PartialView**: `_Layout`, `_Footer`, `_ValidationScriptsPartial` ✔️
- **Footer (sabit)**: `wwwroot/css/site.css` ile sabitlenmiş ✔️
- **Sayfalar**: Ana Sayfa, Hakkında ✔️

## Geliştirme İpuçları
- Bootstrap ile form ve tablo şablonları kolayca genişletilebilir.
- **EF Core**’a geçişte**: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` ve `Microsoft.EntityFrameworkCore.Tools` ekleyin, `DbContext` tanımlayın, `builder.Services.AddDbContext<...>` ile DI'a ekleyin.
