Program został podzielony na 4 warstwy: Models, Logic, AppDatabase i Console

Models - klasy przechowujące dane

Logic - klasy zarządzania i wykonywania operacji na obiektach z warstwy models

Database - warstwa posiadająca klase która odpowiada za przechowywanie obiektów

UI - obsługa menu

Każda z warstw działa indywidualnie i można dowolnie modyfikować elementy jednej klasy bez wpływu na kompilacje reszty

Kohezja - Każda klasa w warstwie Logic odpowiada za swoją część, zgodnie z nazewnictwem. DataManager obsługuje logike zwracania list z konkretnymi warunkami, DatabaseManager obsługuje generalne zarządzanie obiektami (dodawanie, modyfikacja), EquipmentManager jest klasą obsługującą system wypożyczania.

Coupling - Klasa RentEquipment nie przechowuje obiektu, zapisuje jedynie dane tego obiektu - Id

