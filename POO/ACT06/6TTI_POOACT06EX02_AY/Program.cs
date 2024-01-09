namespace _6TTI_POOACT06EX02_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chat chat = new Chat("Pitor", "01/01/2003", "D763", 30, false);
            Chien chien = new Chien("Médor", "01/01/2002", "P893", 50, false);
            Lapin lapin = new Lapin("Flocon", "01/01/2009", "C471", 10, true, 3);

            Console.WriteLine(chat.Afficher());
            Console.WriteLine(chien.Afficher());
            Console.WriteLine(lapin.Afficher());
        }
    }
}