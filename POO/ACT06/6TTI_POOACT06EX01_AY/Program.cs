namespace _6TTI_POOACT06EX01_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Voiture voiture = new Voiture("Essence/Diesel", true, "Ford Focus", "Ford", "noir", 30000);
            Velo velo = new Velo("Vélo électrique de ville", true, "Specialized Turbo Vado", "Specialized", "rouge", 3000);

            Console.WriteLine(voiture.Affiche());
            Console.WriteLine(velo.Affiche());
        }
    }
}