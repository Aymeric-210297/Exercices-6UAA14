namespace _6TTI_POOACT06EX04_AY;
class Program
{
    static void Main(string[] args)
    {
        Employe[] employes = new Employe[10];
        employes[0] = new Ouvrier(new DateTime(2001, 12, 31), 2500, "O789", "Dupont", "Jean", "14/08/1978");
        employes[1] = new Ouvrier(new DateTime(1997, 05, 14), 2500, "O125", "Michel", "Philippe", "19/01/1974");
        employes[2] = new Ouvrier(new DateTime(1996, 10, 10), 2500, "O986", "Colbert", "Henriette", "21/06/1981");
        employes[3] = new Ouvrier(new DateTime(2012, 04, 17), 2500, "O327", "Blanchar", "Renard", "01/09/1991");
        employes[4] = new Ouvrier(new DateTime(2021, 09, 21), 2500, "O852", "Lécuyer", "Maxime", "09/12/1971");
        employes[5] = new Cadre(1, "C496", "Travert", "Julienne", "28/11/1982");
        employes[6] = new Cadre(3, "C837", "Masson", "Thierri", "04/08/1992");
        employes[7] = new Cadre(4, "C791", "Belmont", "Valère", "06/03/1973");
        employes[8] = new Directeur(1_000_000, 2.5, "D145", "Michel", "Adèle", "11/10/1969");
        employes[9] = new Directeur(1_000_000, 3.2, "D777", "Jacinthe", "Pierre", "24/09/1984");

        for (var i = 0; i < employes.Length; i++)
        {
            Console.WriteLine(employes[i].Afficher());
        }
    }
}
