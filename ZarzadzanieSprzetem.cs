using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu;

public class ZarzadzanieSprzetem
{
    private string filePath = "G:\\WSiZ 2023-2024\\Programowanie obiektowe\\Projekt\\Program VCS c#\\WypozyczalniaSprzetu\\sprzet.txt";

    public void DodajSprzet(Sprzet sprzet)
    {
        string line = $"{sprzet.ID},{sprzet.Nazwa},{sprzet.CenaZaDobe}";
        File.AppendAllText(filePath, line + Environment.NewLine);
    }

    public void UsunSprzet(int id)
    {
        var lines = File.ReadAllLines(filePath).ToList();
        var lineToRemove = lines.FirstOrDefault(line => line.StartsWith(id.ToString() + ","));

        if (lineToRemove != null)
        {
            lines.Remove(lineToRemove);
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Usunięto sprzęt.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono sprzętu o podanym ID.");
        }
    }

    public void AktualizujSprzet(Sprzet sprzet)
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(sprzet.ID.ToString()))
            {
                lines[i] = $"{sprzet.ID},{sprzet.Nazwa},{sprzet.CenaZaDobe}";
                break;
            }
        }
        File.WriteAllLines(filePath, lines);
    }

    public List<Sprzet> PobierzSprzety()
    {
        var lines = File.ReadAllLines(filePath);
        return lines.Select(line =>
        {
            var data = line.Split(',');
            return new Sprzet(int.Parse(data[0]), data[1], decimal.Parse(data[2]));
        }).ToList();
    }
}

