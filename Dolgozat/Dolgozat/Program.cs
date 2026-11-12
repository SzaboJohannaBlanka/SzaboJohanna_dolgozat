using System.Reflection.Metadata;
using System.Security.Authentication.ExtendedProtection;

List<Videogames> games = [];

#region file beolvasása
#nullable disable
const string FilePath = "..\\..\\..\\data\\videogames.csv";
using StreamReader sr = new(FilePath);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(',');
    games.Add(new()
    {
        Cim = tmp[0],
        Mufaj = tmp[1],
        KiadasDatum = DateTime.Parse(tmp[2]),
        AktivJatekosok = int.Parse(tmp[3]),
        Ertekeles = float.Parse(tmp[4].Replace('.', ','))
    });
}

#endregion

Console.WriteLine("Feladat1:");
var count = games.Count(p => p.Ertekeles > 4.5);
Console.WriteLine($"{count} db játék van a listában, aminek az értékelése szigorúan nagyobb, mint 4.5");

Console.WriteLine("Feladat2:");
var maxby = games.MaxBy(p => p.AktivJatekosok);
Console.WriteLine($"Legtöbbet játszott:\n {maxby}");

Console.WriteLine("Feladat3:");
var any = games.Any(p => p.KiadasDatum < new DateTime(2020, 1, 1)); 
Console.WriteLine($"{(any ? "van" : "nincs")} ilyen játék");

Console.WriteLine("Feladat4:");
var avg = games.Average(p => p.Ertekeles);
Console.WriteLine($"A játékok értékelésének az átlaga: {avg:0.0}");

Console.WriteLine("Feladat5:");
var where = games.Find(p => p.Cim == "Cyber City 2077");
Console.WriteLine(where);

Console.WriteLine("Feladat6:");
var asd = games.Where(p => p.Mufaj == "RPG").OrderByDescending(p => p.KiadasDatum);
Console.WriteLine($"Az RPG műfajú játékok:");
foreach(var item in asd)
{
    Console.WriteLine($"{item}\n");
}

Console.WriteLine("Feladat7:");
var order = games.OrderByDescending(p => p.Ertekeles).Take(3);
foreach (var a in order)
{
    Console.WriteLine($"{a}\n");
}

Console.WriteLine("Feladat8:");
var average = games.Where(p => p.KiadasDatum >= new DateTime(2020, 1, 1)).Average(p => p.AktivJatekosok);
Console.WriteLine($"{average} az átlagos játékosszám");

Console.WriteLine("Feladat9");
var stat = games
    .GroupBy(j => j.Mufaj)
    .Select(g => new
    {
        Mufaj = g.Key,
        Darab = g.Count()
    });

foreach (var v in stat)
{
    Console.WriteLine($"{v.Mufaj}: {v.Darab} játék");
}

Console.WriteLine("Feladat10");
var maxstat = games
    .GroupBy(j => j.Mufaj)
    .Select(g => new
    {
        Mufaj = g.Key,
        LegjobbJatek = g.MaxBy(j => j.Ertekeles)
    });

foreach (var v in maxstat)
{
    Console.WriteLine($"{v.Mufaj}: {v.LegjobbJatek}");
}
