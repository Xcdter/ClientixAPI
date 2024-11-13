# ClientixAPI

## ��������
������ ������������ ����� ��� ���������� � RESTful Api ��� ���������� �������� � ����������� �������, ������������� �� C# � �������������� ASP.NET Core � Entity Framework Core.

## ���� ����������
- .Net 8.0 (��� ��������� ���������� ������)
- ASP.NET Core
- Entity Framework Core
- SQL Server

## ���������

### ����������
- .NET SDK 8.0 ��� ����
- IDE (��������, Visual Studio 2022)

### ������������ �����������
```bash
git clone https://github.com/Xcdter/ClientixAPI.git
cd ClientixAPI
```
### ��������� ������������
```bash
dotnet restore
```


������ ����������
```bash
dotnet run
```


## ������������� API (������������ ����� OpenAPI ( Swagger ))

### ���������

#### ��������� �������
- GET /api/Client - �������� ���� ��������
- POST /api/Client - �������� ������ �������
- GET /api/Client/{id} - �������� ������� �� ID
- PUT /api/Client/{id} - �������� ������ �������
- DELETE /api/Client/{id} - ������� ������� �� ID

#### ������
- GET /api/Founder - �������� ���� �����������
- GET /api/Founder/{id} - �������� ���������� �� ID
- POST /api/Founder - �������� ������ ����������
- PUT /api/Founder/{id} - �������� ������ ����������
- DELETE /api/Founder/{id} - ������� ���������� �� ID

## ��������� ������
��� ��������� ������ �������������� � ���������������� HTTP-������ ������.

## �������������� �����������
��������� ������� ������ ��� �������� � ���������� ���������.
