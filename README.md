# ClientixAPI

## Описание
Проект представляет собой веб приложение с RESTful Api для управления товарами и категориями товаров, реализованный на C# с использованием ASP.NET Core и Entity Framework Core.

## Стек технологий
- .Net 8.0 (или последняя стабильная версия)
- ASP.NET Core
- Entity Framework Core
- SQL Server

## Установка

### Требования
- .NET SDK 8.0 или выше
- IDE (например, Visual Studio 2022)

### Клонирование репозитория
```bash
git clone https://github.com/Xcdter/ClientixAPI.git
cd ClientixAPI
```
### Усиановка зависимостей
```bash
dotnet restore
```


Запуск приложения
```bash
dotnet run
```


## Использование API (Тестирование через OpenAPI ( Swagger ))

### Эндпоинты

#### Категории товаров
- GET /api/Client - Получить всех клиентов
- POST /api/Client - Добавить нового клиента
- GET /api/Client/{id} - Получить клиента по ID
- PUT /api/Client/{id} - Обновить данные клиента
- DELETE /api/Client/{id} - Удалить клиента по ID

#### Товары
- GET /api/Founder - Получить всех учредителей
- GET /api/Founder/{id} - Получить учредителя по ID
- POST /api/Founder - Добавить нового учредителя
- PUT /api/Founder/{id} - Обновить данные учредителя
- DELETE /api/Founder/{id} - Удалить учредителя по ID

## Обработка ошибок
Все возможные ошибки обрабатываются с соответствующими HTTP-кодами ответа.

## Дополнительные возможности
Валидация входных данных при создании и обновлении сущностей.
