### API

#### Zadanie 1

1. Stwórz kontroler `Movie`.
1. Opatrz kontroler atrybutami `[Route("api/[controller]")]` i `[ApiController]`.
1. Korzystając z klasy FilmManager stwórz akcje `Create`, `Get`, `GetAll`, `Update`, `Delete`.
1. Pamiętajcie o dodaniu odpowiedniego rodzaju odpowiedzi. 
1. Opatrz je odpowiednimi atrybutami metod typu `[HttpPost]`.
1. Wykorzystaj narzędzie Postman do przetestowania kodu.
1. Dla chętnych - wykorzystaj bibliotekę Swagger do testowania swojego API.
https://docs.microsoft.com/pl-pl/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio

#### Zadanie 2

1. Dodaj model gatunek filmu `GenreModel`. 
1. Rozszerz możliwość aplikacji o dodawanie, usuwanie, edycję, wyświetlanie gatunków filmowych.
1. Dodaj możliwość wyświetlenia wszystkich filmów w danym gatunku filmowym.
1. Dodaj gatunek filmowy do modelu `FilmModel`. 
1. Aplikacja będzie zawierała dane o aktorach, imię, nazwisko, datę urodzenia. Aplikacja ma wyświetlać listę aktorów, pozwalać na ich dodawanie, edycję i usuwanie.
1. Aplikacja powinna pozwalać na łączenie filmów z aktorami.
1. Po kliknięciu na liście filmów konkretnego filmu, aplikacja powinna wyświetlić jego podsumowanie wraz z aktorami grającymi w filmie.
1. Po kliknięciu na liście aktorów, aplikacja powinna wyświetlić listę filmów, w których grał aktor.
1. Zmodyfikuj kod w ten sposó, żeby usunać film, gatunek lub aktora mogła tylko osoba o roli `Admin` a edytować osoba o roli `Admin` lub `Moderator`;
1. Dodaj migrację i zaaktualizuj bazę danych.
1. Dodaj nowy kontroler API z danymi o aktorach i kontroler z danymi o gatunkach. Oba mają pozwalać na pobranie pojedyńczego wpisu, kolekcji lub dodanie nowego obiektu.
1. Dostosuj wszystkie elementy aplikacji do nowych wymagań.
1. Pamiętaj o stylach CSS i wykorzystaniu biblioteki Bootstrap.

     
