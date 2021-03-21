# Laboratorium 3
## Web API + simple website

Działająca stronka składa się z 3 podstron, z możliwością nawigacji pomiędzy nimi przy użyciu górnego navbara
+ People CRUD - strona bazująca na kodzie tworzonym podczas zajęć
+ Ludzie - wystylowany interfejs strony bazujący na grafice podanej w zadaniu
+ Książki - bardziej rozwinięty interfejs zawierający ukryte formatki usuwania/dodawania
### Stack
+ Web API
    - .Net 5.0
    - Entity Framework Core Code-First
    - Auto Mapper
    - Baza Danych Sql (wykonanie w oparciu o SQL Server 2019 Express)
+ Site
    - jQuery
### Startup
Projekt posiada dwa typy uruchomieniowe:
+ ISS Express (uruchomienie właściwej aplikacji) - tworzenie bazy danych odbywa się automatycznie - pod warunkiem podania właściwego connection stringa "DefaultConnection" w appsettings.json kierującego do lokalnej instancji serwera SQL 
+ Swagger 