using cave;
using System.Text;

List<Barlang> list = new List<Barlang>();

using StreamReader sr = new("barlangok.txt",Encoding.UTF8);
var elso = sr.ReadLine();
while (!sr.EndOfStream)
{
    list.Add(new Barlang(sr.ReadLine()!));
}
sr.Close();
Console.WriteLine("4. feladat: Barlangok száma: "+list.Count);

var msavg = list.Where(x => x.Telepules.Contains("Miskolc")).Average(b => b.Melyseg);
Console.WriteLine($"5. feladat: Az átlag mélység: {msavg:0.000} m");
Console.Write("6. feladat: Adjon meg egy védettségi szintet: ");
string vedlevel = Console.ReadLine()!;
bool g = false;
for (int i = 0; i < list.Count; i++)
{
    if (list[i].Vedettseg.Contains(vedlevel))
    {
        g = true;
    }
}
if(g)
{
    var leghosszBylevel = list.Where(x => x.Vedettseg == vedlevel).MaxBy(b => b.Hossz);
    Console.WriteLine(leghosszBylevel.ToString());
}
else
{
    Console.WriteLine("Nincs ilyen védettségi szinttel barlang az adatok között");
}
Console.WriteLine("7. feldat: Statisztika");
var br = list.Count(x => x.Vedettseg =="védett");
var br1 = list.Count(x => x.Vedettseg == "megkülönböztetetten védett");
var br2 = list.Count(x => x.Vedettseg == "fokozottan védett");
Console.WriteLine($"\tfokozottan védett: {br2}\n\tmegkülönböztetetten védett: {br1}\n\tvédett: {br}");
