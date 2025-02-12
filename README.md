# Project Showcase API

Project Showcase API, kullanıcıların projeleri ekleyip, güncelleyip, silebileceği ve mevcut projeleri listeleyebileceği bir proje sergileme uygulamasıdır.

## Teknolojiler

- ASP.NET Core
- Entity Framework Core
- FluentValidation
- SQL Server

## API Kullanımı

### Projeleri Listele

```
GET /api/projects
```

Bu endpoint mevcut projeleri listeler.

### Yeni Proje Ekle

```
POST /api/projects
```

Yeni bir proje eklemek için kullanılır. 

### Proje Sil

```
DELETE /api/projects/{id}
```

Belirtilen `id` değerine sahip projeyi silmek için kullanılır.

### Teknoloji Sayıları

```
GET /api/projects/technology-counts
```

Projelerde kullanılan teknolojilerin sayısını gösterir.

## Kullanıcı Arayüzü

`wwwroot/test.html` dosyası, API'yi test etmek için basit bir arayüz sağlar. Tarayıcınızdan bu dosyayı açarak API'nin temel işlevlerini test edebilirsiniz.


