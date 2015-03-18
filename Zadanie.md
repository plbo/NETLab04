Opis zadania
============

Klasa pomocnicza: StringHelper, metoda IsStringValid zwraca fałsz jeżeli tekst w parametrze jest pusty, nie istnieje lub jego długość jest mniejsza niż 3, w innym wypadku prawda

Wyjątki:
* DataValidationException – przechowuje wiadomość o błędzie, typ źródłowy, gdzie wystąpił błąd walidacji oraz zwraca komunikat przyjazny użytkownikowi
* NumberValidationException – jest wywiedziony z DataValidationException, dodatkowo przechowuje liczbę, która nie przeszła walidacji i zwraca odpowiedni komunikat błędu
* TextValidationException – jest wywiedziony z DataValidationException, dodatkowo przechowuje tekst, który nie spełnił walidacji i zwraca odpowiedni komunikat błędu
* GenericDataValidationException – jest wywiedziony z DataValidationException, dodatkowo przechowuje „wartość”, która nie spełniła walidacji i zwraca odpowiedni komunikat błędu

Klasy Person, i dziedziczące po niej BetterPerson zawierają składowe wieku (właściwość Age), imienia (Name), nazwiska (Surname), z odpowiednimi regułami walidacyjnymi dla ustawianych danych


StringHelper
------------
Klasa jest publiczna i statyczna

Zawiera publiczną statyczną metodę o nazwie IsStringValid, która:
* Zwraca typ logiczny (bool)
* Jako parametr przyjmuje tekst (string)
* Ma zaimplementowaną logikę:
** Jeżeli tekst przekazany tekst nie istnieje lub zawiera tylko białe znaki (string.IsNullOrWhiteSpace) zwracany jest fałsz
** Jeżeli długość przekazanego tekstu (właściwość Length) jest mniejsza od 3 to zwracany jest fałsz
** W innych przypadkach zwracana jest prawda


Wyjątki
-------
W kodzie są trzy klasy wyjątków:
* DataValidationException
* NumberValidationException
* TextValidationException

### DataValidationException 
DataValidationException dziedziczy po Exception

DataValidationException zawiera właściwość typu Person o nazwie PersonWithInvalidData

DataValidationException zawiera publiczny konstruktor z parametrami:
* Wiadomość tekstowa (przekazana do klasy bazowej za pomocą konstruktora „base(string)”)
* Osoba, dla której nastąpił błąd typu Person, której wartość jest przypisana do właściwości PersonWithInvalidData

DataValidationException zawiera publiczną metodę (bezparametrową) o nazwie GetUserFriendlyMessage, której implmentacja zwraca wynik wywołania statycznej metody string.Format, z parametrami ValidationErrorMessageFormat, PersonWithInvalidData, UnknownValue, Message


### NumberValidationException 
NumberValidationException dziedziczy po DataValidationException

NumberValidationException zawiera właściwość typu int o nazwie WrongNumber

NumberValidationException zawiera publiczny konstruktor z parametrami:
* Wiadomość tekstowa – przekazana  do klasy bazowej za pomocą konstruktora
* Osoba, dla której nastąpił błąd typu Person – przekazana  do klasy bazowej za pomocą konstruktora
* Wartość liczbowa – przypisana do właściwości WrongNumber

NumberValidationException zawiera (nową) publiczną metodę (bezparametrową) o nazwie GetUserFriendlyMessage, której implmentacja zwraca wynik wywołania statycznej metody string.Format, z parametrami ValidationErrorMessageFormat, PersonWithInvalidData, WrongNumber, Message

### TextValidationException 
TextValidationException dziedziczy po DataValidationException

TextValidationException zawiera właściwość typu string o nazwie WrongTextValue

TextValidationException zawiera publiczny konstruktor z parametrami:
* Wiadomość tekstowa – przekazana  do klasy bazowej za pomocą konstruktora
* Osoba, dla której nastąpił błąd typu Person – przekazana  do klasy bazowej za pomocą konstruktora
* Tekst– przypisana do właściwości WrongTextValue

TextValidationException zawiera (nową) publiczną metodę (bezparametrową) o nazwie GetUserFriendlyMessage, której implmentacja zwraca wynik wywołania statycznej metody string.Format, z parametrami ValidationErrorMessageFormat, PersonWithInvalidData, WrongTextValue, Message

### Person 
Klasa Person zawiera wirtualne właściwości:
* Name, Surname typu string
* Age typu int

Metody ustawiające wartość (set) dokonują walidacji:
* Właściwość Age – jeżeli ustawiana wartość jest ujemna lub większa niż 150 to wyrzucany jest wyjątek typu NumberValidationException „Age is invalid”
* Właściwości Name i Surname – jeżeli ustawiana wartość powoduje zwrócenie wartości typu fałsz przez StringHelper.IsStringValid to wyrzucany jest wyjątek TextValidationException o treści: „Name is invalid”

Aby komunikat błędu w wyjątku został poprawie sformatowany konieczne jest dostarczenie implementacji dla metody ToString, która zwraca łańcuch tekstowy rozdzielony spacją


### GenericDataValidationException
Oczekiwana funkcjonalność:
* Klasa dziedziczy po DataValidationException
* Publiczna właściwość typu Value o nazwie WrongValue (get/set)
* Publiczny konstruktor, który: 
** Przyjmuje tekst wiadomości, obiekt osoby, i wartość typu Value jako parametry
** Tekst wiadomości i osoba jest przekazywana do konstruktora klasy bazowej base(/* */)
** Wartość typu Value jest przypisana do właściwości o nazwie WrongValue 

Posiada „nową” metodę GetUserFriendlyMessage z analogiczną implementacją do poprzednich składowych (zmiana właściwości)


### BetterPerson
Klasa BetterPerson dziedziczy po Person

Klasa przesłania implementację właściwości z klasy Person

Implementacja właściwości dla metod set zawiera walidację (reguły takie same jak w klasie Person)

Niespełnienie warunków walidacyjnych powoduje wyrzucenie wyjątku klasy GenericDataValidationException z odpowiednim typem użytym do parametryzacji (int/string) oraz przekazaniem odpowiedniej wartości do konstruktora 


### Pytania kontrolne
Każdy implementowany wyjątek dostarcza implementację metody GetUserFriendlyMessage, w jakich przypadkach będzie wywołana ta z klasy bazowej, a w jakich z typów dziedziczących?

String.format dla wyjątku wywołała metodę ToString dla przekazanej osoby. Jaki paradygmat OOP za to odpowiada?

W przypadku posiadania odpowiednich sekcji „catch” dla wyjątków DataValidationException i NumberValidationException, oraz wyrzuceniu przez kod użytkownika wyjątku typu NumberValidationException. Kiedy nie dojdzie do wykonania sekcji odpowiadającej dla typu NumberValidationException?

GenericDataValidationException – w momencie konstrukcji tego obiektu ile konstruktorów (niestatycznych) zostało wywołanych?





