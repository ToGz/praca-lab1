# Laboratorium 2
## Razor Pages - Lokalizacja & Inicjalizacja DB

Strona bazująca na tematyce zoo składająca się z 4 podstron, w pełni lokalizowanych na 6 języków.
Każdy z trzech modeli (gatunków) zwierząt posiada dane przykładowe - generowane podczas startupu apkikacji.

### Stack
+ Web API
    - .Net 5.0
    - Razor Pages
    - Entity Framework Core Code-First
    - ResX manager - narzędzie do zarządzania zasobami tłumaczeń
    - Baza Danych Sql (wykonanie w oparciu o SQL Server 2019 Express)

### Startup
+ ISS Express - tworzenie bazy danych odbywa się automatycznie, pod warunkiem podania właściwego connection stringa "DefaultConnection" w appsettings.json kierującego do lokalnej instancji serwera SQL 

### Remarks 
Lokazlizacja opracowana na podstawie:
https://www.mikesdotnetting.com/article/346/using-resource-files-in-razor-pages-localisation
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-5.0
https://www.jetbrains.com/dotnet/guide/tutorials/localization/aspnet/