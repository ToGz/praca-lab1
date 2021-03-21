# Laboratorium 4
## Razor Pages + SignalR & Identity

Aplikacja laboratoryjna zmodyfikowana zgodnie z podanymi zaleceniami:

1. Dodać zapisywanie komunikatów wysyłanych do serwera do bazy danych. W tym celu utworzyć tabelkę \'Messages\' i dodać ją jako część migracji bazy danych w górę (patrz laboratorium 2).
	- Klasa Message dodana do dBsetu wewnątrz kontekstu \"ApplicationDbContext\"
	- Na zakończenie projektu utworzona została zbiorcza migracja \"complete\"

2. Zapisane komunikaty w tabeli Messages wyświetlać na osobnej zakładce \'History\'. Zakładka ta ma wyświetlać tylko komunikaty wysłane przez zalogowanego użytkownika.
	- Zakładka Messages przekierowywuje do razor page\'a \"MessageHistory\" wyświetlając wiadomości przefiltrowane po przekazywanym do warstwy dostępu do danych wartości userId
	- DI repozutorium do ChatHub\'u rozwiązane za pomocą DependencyResolvera dostarczonego w doinstalowanej paczce SignalR.Core

3. Dodać zakładkę \'Users\', która będzie wyświetlać listę zarejestrowanych użytkowników. Zakładka ta ma być widoczna tylko dla użytkownika \'admin@email.com\'.
	- Zakładka Users przekierowywuje do page\'a \"Admin\" wyświetlającego listę wszystkich użytkowników - przy dokonaniu odfiltrowania własnego rekordu
	- \"Zabezpieczenie\" dostępu odbywa się poprzez zastosowanie sprawdzenia if nazwa == \"admin@email.com\" wewnątrz page\'a _Layout 
