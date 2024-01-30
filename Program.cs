namespace WypozyczalniaSprzetu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static ZarzadzanieSprzetem zarzadzanieSprzetem = new ZarzadzanieSprzetem();

        static void Main(string[] args)
        {
            bool dziala = true;
            while (dziala)
            {
                Console.Clear();
                Console.WriteLine("\nWypożyczalnia sprzętu - wybierz opcję:");
                Console.WriteLine("1. Dodaj sprzęt");
                Console.WriteLine("2. Usuń sprzęt");
                Console.WriteLine("3. Aktualizuj sprzęt");
                Console.WriteLine("4. Wypożycz sprzęt");
                Console.WriteLine("5. Pokaż sprzęty");
                Console.WriteLine("6. Wyjście");
                Console.Write("\nWybór: ");

                string opcja = Console.ReadLine();
                switch (opcja)
                {
                    case "1":
                        DodajSprzet();
                        break;
                    case "2":
                        UsunSprzet();
                        break;
                    case "3":
                        AktualizujSprzet();
                        break;
                    case "4":
                        WypozyczSprzet();
                        break;
                    case "5":
                        PokazSprzety();
                        break;
                    case "6":
                        dziala = false;
                        break;
                    default:
                        Console.WriteLine("Nieznana opcja. Naciśnij dowolny klawisz, aby kontynuować.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void DodajSprzet()
        {
            int id = PobierzInt("Podaj ID sprzętu: ");

            // Sprawdzanie, czy sprzęt o tym ID już istnieje
            var istniejacySprzet = zarzadzanieSprzetem.PobierzSprzety().FirstOrDefault(s => s.ID == id);
            if (istniejacySprzet != null)
            {
                Console.WriteLine("Sprzęt o podanym ID już istnieje. Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
                return;
            }

            string nazwa = PobierzString("Podaj nazwę sprzętu: ");
            decimal cena = PobierzDecimal("Podaj cenę za dobę wypożyczenia: ");

            Sprzet sprzet = new Sprzet(id, nazwa, cena);
            zarzadzanieSprzetem.DodajSprzet(sprzet);
            Console.WriteLine("Dodano sprzęt. Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
        }


        static void UsunSprzet()
        {
            int id = PobierzInt("Podaj ID sprzętu do usunięcia: ");
            zarzadzanieSprzetem.UsunSprzet(id);
            Console.WriteLine("Usunięto sprzęt. Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
        }

        static void AktualizujSprzet()
        {
            int id = PobierzInt("Podaj ID sprzętu do aktualizacji: ");
            string nazwa = PobierzString("Podaj nową nazwę sprzętu: ");
            decimal cena = PobierzDecimal("Podaj nową cenę za dobę wypożyczenia: ");

            Sprzet sprzet = new Sprzet(id, nazwa, cena);
            zarzadzanieSprzetem.AktualizujSprzet(sprzet);
            Console.WriteLine("Zaktualizowano sprzęt. Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
        }

        static void WypozyczSprzet()
        {
            int sprzetID = PobierzInt("Podaj ID sprzętu do wypożyczenia: ");
            int liczbaDni = PobierzInt("Podaj liczbę dni wypożyczenia: ");

            Sprzet sprzet = zarzadzanieSprzetem.PobierzSprzety().FirstOrDefault(s => s.ID == sprzetID);
            if (sprzet != null)
            {
                Wypozyczenie wypozyczenie = new Wypozyczenie(sprzetID, DateTime.Now, liczbaDni);
                decimal koszt = wypozyczenie.ObliczKoszt(sprzet.CenaZaDobe);
                Console.WriteLine($"Koszt wypożyczenia: {koszt} zł. Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nie znaleziono sprzętu. Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
            }
        }

        static void PokazSprzety()
        {
            var sprzety = zarzadzanieSprzetem.PobierzSprzety();
            foreach (var sprzet in sprzety)
            {
                Console.WriteLine($"ID: {sprzet.ID}, Nazwa: {sprzet.Nazwa}, Cena za dobę: {sprzet.CenaZaDobe} zł");
            }
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
        }

        static int PobierzInt(string komunikat)
        {
            while (true)
            {
                Console.Write(komunikat);
                if (int.TryParse(Console.ReadLine(), out int wynik))
                    return wynik;
                else
                    Console.WriteLine("Podaj prawidłową wartość liczbową.");
            }
        }

        static decimal PobierzDecimal(string komunikat)
        {
            while (true)
            {
                Console.Write(komunikat);
                if (decimal.TryParse(Console.ReadLine(), out decimal wynik))
                    return wynik;
                else
                    Console.WriteLine("Podaj prawidłową wartość liczbową.");
            }
        }

        static string PobierzString(string komunikat)
        {
            Console.Write(komunikat);
            return Console.ReadLine();
        }
    }
}
